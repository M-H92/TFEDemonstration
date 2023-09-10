import { defineStore } from "pinia";
import jwt_decode from "jwt-decode";

export const useUtilisateurStore = defineStore("utilisateur", {
  state:() => ({
    authJWT : null as string | null,
  }),
  getters: {
    id: (state) => {
      if(state.authJWT === null){
        state.authJWT = localStorage.getItem('authJWT') ?? null;
      }
      if(state.authJWT === null)  
        return '';

      return (jwt_decode(state.authJWT) as any)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] ?? '';
    },
    roles: (state) => {
      if(state.authJWT === null){
        state.authJWT = localStorage.getItem('authJWT') ?? null;
      }
      if(state.authJWT === null)  
        return [];

      return (jwt_decode(state.authJWT) as any)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] ?? [];
    },
    hasRoles: (state) => {
      if(state.authJWT === null){
        state.authJWT = localStorage.getItem('authJWT') ?? null;
      }
      if(state.authJWT === null)  
        return false;

      const roles = (jwt_decode(state.authJWT) as any)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      if(!roles || roles.length === 0)
        return false;
      return true;
    }
  },
  actions:{
    async reset(){
      this.authJWT = null;
      localStorage.removeItem('authJWT');
    },
    async setAuthJWT(jwt : string){
      this.authJWT = jwt;
      localStorage.setItem('authJWT', jwt);
    },
    async deconnexion(){
      this.reset();
    }
  }
}
);

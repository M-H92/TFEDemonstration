import { defineStore } from "pinia";
import ApplicationDTO, { Application } from "@/models/Application/Application";
import AdminDroitApi from "@/api/Admin/AdminDroitsApi";
import { Collaborateur } from "@/models/Admin/Droits/Collaborateur";
import { RoleDescription } from "@/models/Admin/Droits/RoleDescription";
import { RoleCollaborateur } from "@/models/Admin/Droits/RoleCollaborateur";
import SelectItem from "@/models/Vuetify/SelectItem";
import type CreateCollaborateursRolesDTO from "@/models/Admin/Droits/CreateCollaborateurRoleDTO";

export const useAdminDroitStoreStore = defineStore("AdminDroits", {
  state: () => ({
    loading : false,
    collaborateurs : [] as Collaborateur[],
    roles : [] as RoleDescription[],
    rolesCollaborateurs : [] as RoleCollaborateur[]
  }),
  getters: {
    comboxBoxItemsRoles : (state) => state.roles.map(r => new SelectItem(r.libelleFull, r.role)),
    comboxBoxItemsCollab : (state) => state.collaborateurs.map(r => new SelectItem(r.collaborateur, r.collaborateur)),
    collaborateursWithRoles : (state) => {
      state.collaborateurs.map((r) =>{


      })
    },
  },
  actions: {
    async initialize() {
      this.loading = true;
      try {
        const [collaborateurs,roles, rolesCollaborateurs] = await Promise.all([AdminDroitApi.getCollaborateurs(),
                                                                               AdminDroitApi.getRoles(),
                                                                               AdminDroitApi.GetRolesCollaborateurs(),]);
        this.collaborateurs.splice(0 , this.collaborateurs.length, ...collaborateurs.map(c => new Collaborateur(c)));
        this.roles.splice(0 , this.roles.length, ...roles.map(r => new RoleDescription(r)));
        this.rolesCollaborateurs.splice(0 , this.rolesCollaborateurs.length, ...rolesCollaborateurs.map(rc => new RoleCollaborateur(rc)));
        this.rolesCollaborateurs.forEach(rc => {
          const collabIndex = this.collaborateurs.findIndex(c => c.collaborateur === rc.collaborateur);
          const roleIndex = this.roles.findIndex(r => r.role === rc.role);
          if(collabIndex !== -1 && roleIndex !== -1)
            this.collaborateurs[collabIndex].addRole(this.roles[roleIndex]);
        });
        this.collaborateurs.forEach((c) => c.addRole)
      } finally {
        this.loading = false;
      }
    },
    async deleteRolesCollaborateurs(dto : CreateCollaborateursRolesDTO){
      this.loading = true;
      try {
        await AdminDroitApi.DeleteRoleCollaborateurs(dto);
        await this.initialize();
      } finally {
        this.loading = false;
      }
    },
  async addRole(collabRole : CreateCollaborateursRolesDTO){
    this.loading = true;
    try {
      await AdminDroitApi.PostRoleCollaborateurs(collabRole);
      await this.initialize();
    } finally {
      this.loading = false;
    }
  }
  },
});

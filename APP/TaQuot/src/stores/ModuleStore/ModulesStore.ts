import { defineStore } from "pinia";
import SelectItem from "@/models/Vuetify/SelectItem";
import { Module } from "@/models/Module/Module";
import ModuleApi from "@/api/ModuleApi";

export const useModulesStore = defineStore("Modules",{
  state:() => ({
    modules : [] as Module[],
    loadingModules : false
  }),
  getters:{
    comboxBoxItems : (state) => state.modules.map(t => new SelectItem(t.libelle, t.id))
  },
  actions:{
    async initialize(){
        this.loadingModules = true;
        try{
            const resp = await ModuleApi.getModules();
            this.modules.splice(0);
            this.modules.push(...(resp.map(r => new Module(r))));
        }finally{
            this.loadingModules = false;
        }
    }
  }
}
);

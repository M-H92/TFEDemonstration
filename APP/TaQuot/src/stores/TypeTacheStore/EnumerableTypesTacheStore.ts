import { ref, computed, reactive } from "vue";
import { defineStore } from "pinia";
import { TypeTache } from "@/models/TypeTache/TypeTache";
import TypeTacheApi from "@/api/TypeTacheApi";
import SelectItem from "@/models/Vuetify/SelectItem";

export const useTypeTachesStore = defineStore("typeTaches",{
  state:() => ({
    typeTaches : [] as TypeTache[],
    loadingTypeTache : false
  }),
  getters:{
    comboxBoxItems : (state) => state.typeTaches.map(t => new SelectItem(t.libelle, t.id))
  },
  actions:{
    async initialize(){
        this.loadingTypeTache = true;
        try{
            const resp = await TypeTacheApi.getTypeTaches();
            this.typeTaches.splice(0);
            this.typeTaches.push(...(resp.map(r => new TypeTache(r))));
        }finally{
            this.loadingTypeTache = false;
        }
    }
  }
}
);

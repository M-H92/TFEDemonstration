import { defineStore } from "pinia";
import CollaborateurApi from "@/api/CollaborateurApi";
import { Statut } from "@/models/Statut/Statut";
import StatutApi from "@/api/StatutApi";
import SelectItem from "@/models/Vuetify/SelectItem";

export const useStatutStore = defineStore("Statut", {
  state: () => ({
    loading : false,
    statuts : [] as Statut[],
  }),
  getters: {
    comboxBoxItems: (state) => state.statuts.map((t) => new SelectItem(t.libelle, t.id)),
  },
  actions: {
    async initialize() {
      this.loading = true;
      try {
        const response = await StatutApi.get();
        this.statuts = response.map(s => new Statut(s));
      } finally {
        this.loading = false;
      }
    },
  },
});

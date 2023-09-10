import { defineStore } from "pinia";
import { Collaborateur } from "@/models/Admin/Droits/Collaborateur";
import CollaborateurApi from "@/api/CollaborateurApi";

export const useCollaborateurStore = defineStore("Collaborateur", {
  state: () => ({
    loading : false,
    collaborateurs : [] as Collaborateur[],
  }),
  getters: {
  },
  actions: {
    async initialize() {
      this.loading = true;
      try {
        const response = await CollaborateurApi.getCollaborateurs();
        this.collaborateurs = [...response.map(c => new Collaborateur(c))];
      } finally {
        this.loading = false;
      }
    },
  },
});

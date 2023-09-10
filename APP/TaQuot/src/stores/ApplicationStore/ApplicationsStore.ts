import { defineStore } from "pinia";
import SelectItem from "@/models/Vuetify/SelectItem";
import ApplicationDTO, { Application } from "@/models/Application/Application";
import ApplicationApi from "@/api/ApplicationApi";

export const useApplicationsStore = defineStore("Applications", {
  state: () => ({
    applications: [] as Application[],
    loadingApplications: false,
  }),
  getters: {
    comboxBoxItems: (state) =>
      state.applications.map((t) => new SelectItem(t.libelle, t.id)),
    applicationList: (state) =>
      state.applications.map((a) => new Application(a)),
  },
  actions: {
    GetName(id: string): string {
      return this.applications.find((a) => a.id === id)?.libelle ?? "";
    },
    GetCommanditaireId(applicationId: string): string {
      return (
        this.applications.find((a) => a.id === applicationId)
          ?.commanditaireId ?? ""
      );
    },
    async initialize() {
      this.loadingApplications = true;
      try {
        const resp = await ApplicationApi.getApplications();
        this.applications.splice(0);
        this.applications.push(...resp.map((r) => new Application(r)));
      } finally {
        this.loadingApplications = false;
      }
    },
  },
});

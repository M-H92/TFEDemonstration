import { defineStore } from "pinia";
import SelectItem from "@/models/Vuetify/SelectItem";
import { Commanditaire } from "@/models/Commanditaire/Commanditaire";
import CommanditaireApi from "@/api/CommanditaireApi";

export const useCommanditairesStore = defineStore("Commanditaires", {
  state: () => ({
    commanditaires: [] as Commanditaire[],
    loadingCommanditaires: false,
  }),
  getters: {
    comboxBoxItems: (state) =>
      state.commanditaires.map((t) => new SelectItem(t.nom, t.id)),
  },
  actions: {
    GetName(id: string): string {
      return this.commanditaires.find((c) => c.id === id)?.nom ?? "";
    },
    async initialize() {
      this.loadingCommanditaires = true;
      try {
        const resp = await CommanditaireApi.getCommanditaires();
        this.commanditaires.splice(0);
        this.commanditaires.push(...resp.map((r) => new Commanditaire(r)));
      } finally {
        this.loadingCommanditaires = false;
      }
    },
  },
});

import { defineStore } from "pinia";

export const useNommenclatureStore = defineStore("nommenclature", {
  state: () => ({
    module : 'issue',
    application : 'fonctionnalité',
    commanditaire : 'client',
    tache : 'tâche',
    // module : 'module',
    // application : 'application',
    // commanditaire : 'commanditaire',
    // tache : 'tâche',
    loading : false,

  }),
  getters: {
    moduleCapitalized: (state) => `${state.module[0].toUpperCase()}${state.module.substring(1)}`,
    moduleUpper: (state) => state.module.toUpperCase(),

    applicationCapitalized: (state) => `${state.application[0].toUpperCase()}${state.application.substring(1)}`,
    applicationUpper: (state) => state.application.toUpperCase(),

    commanditaireCapitalized: (state) => `${state.commanditaire[0].toUpperCase()}${state.commanditaire.substring(1)}`,
    commanditaireUpper: (state) => state.commanditaire.toUpperCase(),

    tacheCapitalized: (state) => `${state.tache[0].toUpperCase()}${state.tache.substring(1)}`,
    tacheUpper: (state) => state.tache.toUpperCase(),
    
  },
  actions: {
  }
}
);

import { defineStore } from "pinia";
import { useApplicationsStore } from "../ApplicationStore/ApplicationsStore";
import { useModulesStore } from "../ModuleStore/ModulesStore";
import { useCommanditairesStore } from "../CommanditaireStore/CommanditairesStore";
import { useTypeTachesStore } from "../TypeTacheStore/EnumerableTypesTacheStore";
import SelectItem from "@/models/Vuetify/SelectItem";
import Prestation from "@/models/prestation/prestation";
import { useUtilisateurStore } from "../UtilisateurStore/UtilisateurStore";
import PrestationApi from "@/api/prestationApi";
import ConfigurationDTO, {
  Configuration,
} from "@/models/prestation/configuration";
import { useTheDailyWheelStore } from "../Widget/TheDailyWheelStore";

export const usePrestationStore = defineStore("prestation", {
  state: () => ({
    loading: false,

    date: 0,
    commanditaireId: "",
    applicationId: "",
    moduleId: "",
    tache: "",
    commantaire: "",
    typeTacheId: "",
    temps: 0,

    dateInitialisationCreationTaQuot: "",

    configuration: new Configuration(),
    prestationsPaginated: [] as Prestation[],

    commanditaireStore: useCommanditairesStore(),
    applicationsStore: useApplicationsStore(),
    modulesStore: useModulesStore(),
    typeTachesStore: useTypeTachesStore(),
    utilisateurStore: useUtilisateurStore(),
    theDailyWheelStore: useTheDailyWheelStore(),
  }),
  getters: {
    commanditairesItems: (state) =>
      state.commanditaireStore.commanditaires.map(
        (c) => new SelectItem(c.nom, c.id)
      ),
    applicationsItems: (state) => [
      { title: "", value: "" },
      ...state.applicationsStore.applications
        .filter((a) => a.commanditaireId === state.commanditaireId)
        .map((a) => new SelectItem(a.libelle, a.id)),
    ],
    moduleItems: (state) =>
      state.modulesStore.modules
        .filter((a) => a.applicationId === state.applicationId)
        .map((a) => new SelectItem(a.libelle, a.id)),
    typetachesItems: (state) =>
      state.typeTachesStore.typeTaches.map(
        (t) => new SelectItem(t.libelle, t.id)
      ),
    prestationsIndex: (state) => state.prestationsPaginated,
    isLoading: (state) => state.loading,
    dateInitialisationCreationTaQuot: (state) => {
      let date = new Date();
      if (
        state.configuration.initAtLastDate !== null &&
        state.configuration.initAtLastDate &&
        state.prestationsPaginated !== null &&
        state.prestationsPaginated.length !== 0
      ) {
        const copiedPagination = [...state.prestationsPaginated];
        date = copiedPagination.sort((first, second) => {
          if (new Date(first.date) < new Date(second.date)) {
            return -1;
          } else if (new Date(first.date) > new Date(second.date)) {
            return 1;
          }
          if (first.displayNumber < second.displayNumber) {
            return 1;
          }
          return -1;
        })[state.prestationsPaginated.length - 1].date;
      }
      return `${date.getFullYear()}-${
        date.getMonth() + 1 < 10
          ? `0${date.getMonth() + 1}`
          : `${date.getMonth() + 1}`
      }-${date.getDate() < 10 ? `0${date.getDate()}` : `${date.getDate()}`}`;
    },
  },
  actions: {
    async initialize() {
      this.loading = true;
      try {
        const response = await PrestationApi.getConfiguration(
          this.utilisateurStore.id
        );
        this.setConfiguration(response);
        this.loadPrestations();
      } finally {
        this.loading = false;
      }
    },
    setConfiguration(dto: ConfigurationDTO) {
      this.configuration = new Configuration(dto);
    },
    resetApplicationId() {
      this.applicationId = "";
      this.resetModuleId();
    },
    resetModuleId() {
      this.moduleId = "";
    },
    async loadPrestations() {
      const result = await PrestationApi.getPrestations(
        this.utilisateurStore.id
      );
      this.theDailyWheelStore.initialyze();
      this.prestationsPaginated.splice(0, this.prestationsPaginated.length);
      result.forEach((e) => {
        const prestation = new Prestation();
        prestation.id = e.id;
        prestation.issueGitLab = e.issueGitLab;
        prestation.displayNumber = e.displayNumber;
        prestation.commentaire = e.commentaire;
        prestation.tache = e.tache;
        prestation.typeTache = e.typeTache;
        prestation.commanditaire = e.commanditaire;
        prestation.application = e.application;
        prestation.module = e.module;
        prestation.date = new Date(e.date);
        prestation.temps = e.temps;
        this.prestationsPaginated.push(prestation);
      });
      this.prestationsPaginated.sort((first, second) => {
        if (new Date(first.date) < new Date(second.date)) {
          return 1;
        } else if (new Date(first.date) > new Date(second.date)) {
          return -1;
        }
        if (first.displayNumber < second.displayNumber) {
          return 1;
        }
        return -1;
      });
    },
  },
});

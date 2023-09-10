import { defineStore } from "pinia";
import { useCommanditairesStore } from "@/stores/CommanditaireStore/CommanditairesStore";
import { useTypeTachesStore } from "@/stores/TypeTacheStore/EnumerableTypesTacheStore";
import { useStatutStore } from "@/stores/Shared/StatutStore";
import ParametresFacturationApi from "@/api/Params/ParametresFacturationApi";
import { ParametresFacturation } from "@/models/Params/ParametresFacturation";
import { ParametresCommanditaireTypeTacheStatutGet } from "@/models/Params/ParametresCommanditaireTypeTacheStatutGet";

export const useParametresFacturationStore = defineStore(
  "parametresFacturation",
  {
    state: () => ({
      loading: false,
      parametresFacturations: [] as ParametresFacturation[],
      _commanditaireStore: useCommanditairesStore(),
      _typeTacheStore: useTypeTachesStore(),
      _statut: useStatutStore(),
    }),
    getters: {
      isLoading: (state) => state.loading,
      commanditaires: (state) => state._commanditaireStore.comboxBoxItems,
      typeTache: (state) => state._typeTacheStore.comboxBoxItems,
      statut: (state) => state._statut.comboxBoxItems,
    },
    actions: {
      async loadParams(
        dto = null as ParametresCommanditaireTypeTacheStatutGet | null
      ) {
        try {
          this.loading = true;
          const resp = await ParametresFacturationApi.get(dto);
          this.parametresFacturations = resp.map(
            (dto) => new ParametresFacturation(dto)
          );
        } finally {
          this.loading = false;
        }
      },
      async initialize() {
        this.loading = true;
        try {
          const promise = ParametresFacturationApi.get();
          await Promise.all([
            this._commanditaireStore.initialize(),
            this._typeTacheStore.initialize(),
            this._statut.initialize(),
          ]);
          this.parametresFacturations = (await promise).map(
            (dto) => new ParametresFacturation(dto)
          );
        } finally {
          this.loading = false;
        }
      },
      async create(dto: ParametresFacturation) {
        try {
          this.loading = true;
          await ParametresFacturationApi.post(dto);
          this.loadParams(new ParametresCommanditaireTypeTacheStatutGet(dto));
        } finally {
          this.loading = false;
        }
      },
      async update(dto: ParametresFacturation) {
        try {
          this.loading = true;
          await ParametresFacturationApi.put(dto);
          this.loadParams(new ParametresCommanditaireTypeTacheStatutGet(dto));
        } finally {
          this.loading = false;
        }
      },
      async delete(dto: ParametresFacturation) {
        try {
          this.loading = true;
          await ParametresFacturationApi.delete(dto);
          this.loadParams();
        } finally {
          this.loading = false;
        }
      },
    },
  }
);

import { defineStore } from "pinia";
import api from "@/api/prestationApi";
import type Prestation from "@/models/prestation/prestation";

export const useTheDailyWheelStore = defineStore("theDailyWheel", {
  state: () => ({
    loading: false,
    prestationJournalieres: [] as Prestation[],
  }),
  getters: {
    dailyTotal: (state) => {
      if (
        !state.prestationJournalieres ||
        state.prestationJournalieres.length === 0
      )
        return 0;
      return state.prestationJournalieres
        .map((p) => p.temps)
        .reduce((a, b) => a + b);
    },
    dailyTotalPercentage: (state) =>
      (((state.dailyTotal as number) / 480) * 100).toFixed(2),
  },
  actions: {
    async initialyze() {
      try {
        this.loading = true;
        this.prestationJournalieres = await api.getToday();
      } finally {
        this.loading = false;
      }
    },
  },
});

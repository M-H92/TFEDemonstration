import { defineStore } from "pinia";
import { useCollaborateurStore } from "../Shared/CollaborateurStore";
import RecapDetailleApi from "@/api/RecapDetailleApi";
import { TypeTacheStats } from "@/models/RecapDetaille/TypeTacheStats";

export const useRecapDetailleStore = defineStore("recapDetaille", {
  state: () => ({
    loading : false,
    typeTacheStats : [] as TypeTacheStats[],
    backwardMonths : 0,
    joursPrestes : 0,
    _collaborateurStore : useCollaborateurStore()
}),
  getters: {
    isLoading : (state) => state.loading,
    collaborateurs : (state) => state._collaborateurStore.collaborateurs.map(c => c.collaborateur),
    totalTime : (state) => {
      const totalTimes = state.typeTacheStats.map(t => t.getTotalTime()) 
      return totalTimes.length > 0 ? totalTimes.reduce((a,b) => a+b) : 0
    },
  },
  actions: {
    async initialize(){
      this.loading = true;
      try{
        await this._collaborateurStore.initialize();
      }finally{
        this.loading = false;
      }
    },
    async analyze(){
      this.loading = true;
      try{
        const [typeTachesStats, joursPrestes] = await Promise.all([RecapDetailleApi.getTypeTacheStats(this.backwardMonths),RecapDetailleApi.getNombreJourPrestes(this.backwardMonths)]);
        this.typeTacheStats = typeTachesStats.map(r => new TypeTacheStats(r));
        this.joursPrestes = joursPrestes;
      }finally{
        this.loading = false;
      }
    }
  }
}
);

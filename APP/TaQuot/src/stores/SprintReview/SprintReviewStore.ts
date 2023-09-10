import { defineStore } from "pinia";
import { useCollaborateurStore } from "../Shared/CollaborateurStore";
import SprintReviewApi from "@/api/SprintReviewApi";
import type { ParamsGetSprintReviewStatDTO } from "@/models/SprintReview/ParamsGetSprintReviewStat";
import { SprintReviewStats } from "@/models/SprintReview/SprintReviewStats";

export const useSprintReviewStore = defineStore("sprintReview", {
  state: () => ({
    loading : false,
    sprintReviewStats : [] as SprintReviewStats[],
    selectedCollaborateurs : [] as string[],
    _collaborateurStore : useCollaborateurStore()
}),
  getters: {
    isLoading : (state) => state.loading,
    collaborateurs : (state) => state._collaborateurStore.collaborateurs.map(c => c.collaborateur),
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
    async analyze(dto : ParamsGetSprintReviewStatDTO){
      this.loading = true;
      try{
        const response = await SprintReviewApi.getSprintIssueStats(dto);
        this.sprintReviewStats = response.map(r => new SprintReviewStats(r));
        this.selectedCollaborateurs = dto.collaborateurs;
      }finally{
        this.loading = false;
      }
    }
  }
}
);

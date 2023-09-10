import type { ParamsGetSprintReviewStatDTO } from "@/models/SprintReview/ParamsGetSprintReviewStat";
import type SprintReviewStatsDTO from "@/models/SprintReview/SprintReviewStats";
import axios from "axios";

export default class SprintReviewApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_ADMIN}SprintReview`;

  static async getSprintIssueStats(dto : ParamsGetSprintReviewStatDTO): Promise<SprintReviewStatsDTO[]> {
    const resp = await axios.post(`${this.baseUrl}`, dto );
    return resp.data;
  }
}

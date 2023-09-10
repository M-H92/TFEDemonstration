import type TypeTacheStatsDTO from "@/models/RecapDetaille/TypeTacheStats";
import axios from "axios";

export default class RecapDetailleApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_ADMIN}RecapitulatifDetaille`;

  static async getTypeTacheStats(backwardMonths : number): Promise<TypeTacheStatsDTO[]> {
    const resp = await axios.get(`${this.baseUrl}`, { params: { backwardMonths } } );
    return resp.data;
  }

  static async getNombreJourPrestes(backwardMonths : number): Promise<number>{
    const resp = await axios.get(`${this.baseUrl}/JoursPrestes`, { params: { backwardMonths } } );
    return resp.data;
  }
}

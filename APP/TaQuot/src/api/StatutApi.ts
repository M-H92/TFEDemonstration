import type StatutDTO from "@/models/Statut/Statut";
import axios from "axios";

export default class StatutApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Statut`;

  static async get(): Promise<StatutDTO[]> {
    const resp = await axios.get(`${this.baseUrl}`);
    return resp.data;
  }

}

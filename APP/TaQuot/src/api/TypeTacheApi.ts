import type TypeTacheDTO from "@/models/TypeTache/TypeTache";
import axios from "axios";

export default class TypeTacheApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}TypeTache`;

  static async getTypeTaches(): Promise<TypeTacheDTO[]> {
    const resp = await axios.get(`${this.baseUrl}`);
    return resp.data;
  }
}

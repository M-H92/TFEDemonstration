import type CollaborateurDTO from "@/models/Admin/Droits/Collaborateur";
import axios from "axios";

export default class CollaborateurApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_ADMIN}Permissions`;

  static async getCollaborateurs(): Promise<CollaborateurDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Collaborateurs`);
    return resp.data;
  }
}

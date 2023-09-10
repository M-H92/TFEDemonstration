import type ApplicationDTO from "@/models/Application/Application";
import axios from "axios";

export default class ApplicationApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Applications`;
  static adminUrl = `${import.meta.env.VITE_API_URL_ADMIN}Applications`;

  static async getApplications(): Promise<ApplicationDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Commanditaires`);
    return resp.data;
  }

  static async postApplication(dto: ApplicationDTO): Promise<ApplicationDTO> {
    const resp = await axios.post(`${this.adminUrl}`, dto);

    return resp.data;
  }
}

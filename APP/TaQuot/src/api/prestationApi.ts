import type ConfigurationDTO from "@/models/prestation/configuration";
import type CreateprestationDTO from "@/models/prestation/createPrestationDTO";
import type DetailPrestationDTO from "@/models/prestation/detailPrestationDTO";
import type Prestation from "@/models/prestation/prestation";
import type UpdateConfigurationDTO from "@/models/prestation/updateConfigurationDTO";
import type UpdatePrestationDTO from "@/models/prestation/updatePrestationDTO";
import axios from "axios";

export default class PrestationApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Prestation`;

  static async getPrestations(user: string): Promise<Prestation[]> {
    const resp = await axios.get(`${this.baseUrl}?User=${user}`);
    return resp.data;
  }

  static async get(id: string): Promise<DetailPrestationDTO> {
    const resp = await axios.get(`${this.baseUrl}/${id}`);
    return resp.data;
  }

  static async getToday(): Promise<Prestation[]> {
    const resp = await axios.get(`${this.baseUrl}/Today`);
    return resp.data;
  }

  static async getConfiguration(id: string): Promise<ConfigurationDTO> {
    const resp = await axios.get(`${this.baseUrl}/Configuration?User=${id}`);

    return resp.data;
  }

  static async postPrestation(taquot: CreateprestationDTO) {
    const resp = await axios.post(`${this.baseUrl}`, taquot);
    return resp.data;
  }

  static async putPrestation(id: string, taquot: UpdatePrestationDTO) {
    const resp = await axios.put(`${this.baseUrl}/${id}`, taquot);
    return resp.data;
  }

  static async deletePrestations(id: string) {
    const resp = await axios.delete(`${this.baseUrl}/${id}`);

    return resp.data;
  }

  static async putConfiguration(dto: UpdateConfigurationDTO) {
    const resp = await axios.put(`${this.baseUrl}/Configuration`, dto);

    return resp.data;
  }
}

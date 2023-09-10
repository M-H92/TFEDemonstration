import type { ParametresCommanditaireTypeTacheStatutGet } from "@/models/Params/ParametresCommanditaireTypeTacheStatutGet";
import type ParametresFacturationDTO from "@/models/Params/ParametresFacturation";
import axios from "axios";

export default class ApplicationApi {
  static adminUrl = `${
    import.meta.env.VITE_API_URL_ADMIN
  }ParametresCommanditaireTypeTacheStatut`;

  static async get(
    dto = null as ParametresCommanditaireTypeTacheStatutGet | null
  ): Promise<ParametresFacturationDTO[]> {
    const resp = await axios.get(`${this.adminUrl}`, { params: dto });
    return resp.data;
  }
  static async post(dto: ParametresFacturationDTO): Promise<void> {
    const resp = await axios.post(`${this.adminUrl}`, dto);
    return resp.data;
  }
  static async put(dto: ParametresFacturationDTO): Promise<void> {
    const resp = await axios.put(`${this.adminUrl}`, dto);
    return resp.data;
  }
  static async delete(dto: ParametresFacturationDTO): Promise<void> {
    const resp = await axios.delete(`${this.adminUrl}`, { params: dto });
    return resp.data;
  }
}

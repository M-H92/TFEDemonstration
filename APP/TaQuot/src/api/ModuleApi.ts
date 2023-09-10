import type CreateModuleDTO from "@/models/Module/CreateModule";
import type ModuleDTO from "@/models/Module/Module";
import axios from "axios";

export default class ModuleApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Modules`;
  static adminUrl = `${import.meta.env.VITE_API_URL_ADMIN}Modules`;

  static async getModules(): Promise<ModuleDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Application`);
    return resp.data;
  }

  static async postModule(dto: CreateModuleDTO): Promise<void> {
    const resp = await axios.post(`${this.adminUrl}`, dto);
    return resp.data;
  }
}

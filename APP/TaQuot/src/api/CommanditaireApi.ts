import type CommanditaireDTO from "@/models/Commanditaire/Commanditaire";
import axios from "axios";

export default class CommanditaireApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Commanditaire`;
  static adminUrl = `${import.meta.env.VITE_API_URL_ADMIN}Commanditaire`;

  static async getCommanditaires(): Promise<CommanditaireDTO[]> {
    const resp = await axios.get(`${this.baseUrl}`);
    return resp.data;
  }

  static async postCommanditaire(
    dto: CommanditaireDTO
  ): Promise<CommanditaireDTO> {
    const resp = await axios.post(`${this.adminUrl}`, dto);
    return resp.data;
  }
}

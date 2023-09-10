import type WeeklyRecapDTO from "@/models/Admin/Recap/weeklyRecap";
import type ApplicationDTO from "@/models/Application/Application";
import axios from "axios";

export default class ApplicationApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_ADMIN}Recap`;

  static async getWeeklyRecap(week: string): Promise<WeeklyRecapDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Week/${week}`);
    return resp.data;
  }
}

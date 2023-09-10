import type ExportableLigneFacturableDTO from "@/models/Facturation/ExportableLigneFacturable";
import type LigneFacturableDTO from "@/models/Facturation/LigneFacturable";
import axios from "axios";

export default class FacturationApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}Facturation`;

  static async getFacturable(dateDebut : string, dateFin : string): Promise<LigneFacturableDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Facturable`,
        { params: { dateDebut, dateFin } } 
    );
    return resp.data;
  }
  static async exportFacturable(dto : ExportableLigneFacturableDTO): Promise<any> {
    const resp = await axios.post(`${this.baseUrl}/Facturable/Export`, dto, {responseType: 'blob'});
    return resp;
  }
}

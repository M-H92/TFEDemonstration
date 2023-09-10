import type CollaborateurDTO from "@/models/Admin/Droits/Collaborateur";
import type CreateCollaborateursRolesDTO from "@/models/Admin/Droits/CreateCollaborateurRoleDTO";
import type RoleCollaborateurDTO from "@/models/Admin/Droits/RoleCollaborateur";
import type RoleDescriptionDTO from "@/models/Admin/Droits/RoleDescription";
import axios from "axios";

export default class AdminDroitApi {
  static baseUrl = `${import.meta.env.VITE_API_URL_ADMIN}Permissions`;

  static async getRoles(): Promise<RoleDescriptionDTO[]> {
    const resp = await axios.get(`${this.baseUrl}`);
    return resp.data;
  }
  static async getCollaborateurs(): Promise<CollaborateurDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/Collaborateurs`);
    return resp.data;
  }
  static async GetRolesCollaborateurs(): Promise<RoleCollaborateurDTO[]> {
    const resp = await axios.get(`${this.baseUrl}/RolesCollaborateurs`);
    return resp.data;
  }
  static async PostRoleCollaborateurs(dto : CreateCollaborateursRolesDTO) {
    const resp = await axios.post(`${this.baseUrl}/RolesCollaborateurs`, dto)
    return resp.data;
  }
  static async DeleteRoleCollaborateurs(dto : CreateCollaborateursRolesDTO) {
    const resp = await axios.delete(`${this.baseUrl}/RolesCollaborateurs`, {data : dto})
    return resp.data;
  }
}

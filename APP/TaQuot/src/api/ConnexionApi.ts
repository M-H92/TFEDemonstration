import type ConnexionDTO from "@/models/Connexion/connexionDTO";
import type CreateAccountDTO from "@/models/Connexion/createAccountDTO";
import axios from "axios";

export default class ConnexionApi {
  static authUrl = `${import.meta.env.VITE_API_URL_AUTH}`;
  static baseUrl = `${import.meta.env.VITE_API_URL_COLLAB}`;

  static async postNewAccount(dto : CreateAccountDTO){
    const resp = await axios.post(`${this.authUrl}Account`, dto)
    return resp.data;
  }

  static async authenticate(dto : ConnexionDTO){
    const resp = await axios.post(`${this.authUrl}Authentication`, dto)
    return resp.data;
  }

  static async getRoles(authToken : string){
    const config = {
        headers : {
            'authentication' : authToken
        }
    }
    const resp = await axios.get(`${this.baseUrl}Permissions`,
        config
    )

    return resp.data;
  }
}

import type { ParametresFacturation } from "./ParametresFacturation";

export default class ParametresCommanditaireTypeTacheStatutGetDTO {
  commanditaireId = "";
  typeTacheId = "";
  statutDefautId = "";
  skip = 0;
  take = 10;
}

export class ParametresCommanditaireTypeTacheStatutGet extends ParametresCommanditaireTypeTacheStatutGetDTO {
  public constructor(
    dto:
      | ParametresCommanditaireTypeTacheStatutGetDTO
      | ParametresFacturation
      | null = null
  ) {
    super();
    if (dto) Object.assign(this, dto);
  }
}

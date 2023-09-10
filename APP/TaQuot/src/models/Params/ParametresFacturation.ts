export default class ParametresFacturationDTO {
  commanditaireId = "";
  typeTacheId = "";
  statutDefautId = "";
}

export class ParametresFacturation extends ParametresFacturationDTO {
  public constructor(dto: ParametresFacturationDTO | null = null) {
    super();
    if (dto) Object.assign(this, dto);
  }
}

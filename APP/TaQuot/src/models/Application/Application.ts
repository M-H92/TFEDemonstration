export default class ApplicationDTO {
  id = "";
  libelle = "";
  commanditaireId = "";
}

export class Application extends ApplicationDTO {
  public constructor(dto: ApplicationDTO | null = null) {
    super();

    if (dto?.id) {
      this.id = dto.id;
    }

    if (dto?.libelle) {
      this.libelle = dto.libelle;
    }

    if (dto?.commanditaireId) {
      this.commanditaireId = dto.commanditaireId;
    }
  }
}

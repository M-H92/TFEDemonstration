import type LigneFacturableDTO from "./LigneFacturable";
import LigneFacturableKey from "./LigneFacturableKey";

export default class ExportableLigneFacturableDTO{
  dateDebut = '';
  dateFin = '';
  ligneFacturableDTOs = [] as LigneFacturableKey[];
}
export class ExportableLigneFacturable extends ExportableLigneFacturableDTO{
  ligneFacturableDTOs = [] as LigneFacturableKey[];

  public constructor(dto = null as ExportableLigneFacturableDTO | null){
    super();
    if(dto !== null)
      Object.assign(this, dto)
  }

  public addLigneFacturableKey(ligne : LigneFacturableDTO){
    this.ligneFacturableDTOs.push(new LigneFacturableKey(ligne));
  }

  public addLignesFacturables(lignes : LigneFacturableDTO[]){
    lignes.forEach(ligne => {
      this.addLigneFacturableKey(ligne);
    });
  }
}
import type LigneFacturableDTO from "./LigneFacturable";

export default class LigneFacturableKey {
  tache = '';
  moduleId = '';
  typeTacheId = '';
  statutId = '';

  public constructor(ligneFacturable : LigneFacturableDTO | null){
    if(ligneFacturable !== null)
    {
      this.tache = ligneFacturable.tache;
      this.moduleId = ligneFacturable.moduleId;
      this.typeTacheId = ligneFacturable.typeTacheId;
      this.statutId = ligneFacturable.statutId;
    }
  }
}
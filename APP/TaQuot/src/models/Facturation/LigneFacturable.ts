export default class LigneFacturableDTO{
  commanditaire = '';
  module = '';
  application = '';
  tache = '';
  typeTache = '';
  statut = '';
  moduleId = '';
  typeTacheId = '';
  statutId = '';
  timeSpent = 0;
}

export class LigneFacturable extends LigneFacturableDTO{
  public constructor(dto : LigneFacturableDTO | null = null){
    super();
    if(dto != null)
      Object.assign(this, dto);
  }
}
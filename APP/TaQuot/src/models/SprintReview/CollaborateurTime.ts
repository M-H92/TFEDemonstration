export default class CollaborateurTimeDTO{
  collaborateur = '';
  spentTime = 0;
}

export class CollaborateurTime extends CollaborateurTimeDTO{
  public constructor(dto : CollaborateurTimeDTO | null){
    super();
    if(dto){
      this.collaborateur = dto.collaborateur ? dto.collaborateur : '';
      this.spentTime = dto.spentTime ? dto.spentTime : 0;
    }
  }
}
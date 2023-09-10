import type CollaborateurTimeDTO from "../SprintReview/CollaborateurTime";
import { CollaborateurTime } from "../SprintReview/CollaborateurTime";

export default class TypeTacheStatsDTO{
  label = '';
  collaborateurTimes = [] as CollaborateurTimeDTO[];
}

export class TypeTacheStats extends TypeTacheStatsDTO {
  public constructor(dto : TypeTacheStatsDTO | null){
    super();
    if(dto){
      this.label = dto.label ? dto.label : '';
      this.collaborateurTimes = dto.collaborateurTimes ? dto.collaborateurTimes.map(ct => new CollaborateurTime(ct)) : [];
    }
  }

  public getTimeForCollaborateur(collaborateur : string){
    return this.collaborateurTimes.find(c => c.collaborateur.toUpperCase() === collaborateur.toUpperCase())?.spentTime ?? 0
  }

  public getTotalTime(){
    const spentTime = this.collaborateurTimes.map(c => c.spentTime);
    return spentTime.length > 0 ? spentTime.reduce((a,b) => a+b) : 0
  }
}
import type CollaborateurTimeDTO from "./CollaborateurTime";
import { CollaborateurTime } from "./CollaborateurTime";

export default class SprintReviewStatsDTO{
  label = '';
  collaborateurTimes = [] as CollaborateurTimeDTO[];
}

export class SprintReviewStats extends SprintReviewStatsDTO {
  public constructor(dto : SprintReviewStatsDTO | null){
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
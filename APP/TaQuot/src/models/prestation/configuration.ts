export default class ConfigurationDTO{
  public resetTypeTache = false;
  public resetCommanditaire = false;
  public resetApplication = false;
  public resetModule = false;
  public initAtLastDate = false;
  public tempsAsInputTypeTime = false;
}

export class Configuration extends ConfigurationDTO{
  constructor(dto: Configuration | ConfigurationDTO | null = null) {
    super();
    if (dto instanceof ConfigurationDTO) {
      this.resetTypeTache = dto.resetTypeTache;
      this.resetCommanditaire = dto.resetCommanditaire;
      this.resetApplication = dto.resetApplication;
      this.resetModule = dto.resetModule;
      this.initAtLastDate = dto.initAtLastDate;
      this.tempsAsInputTypeTime = dto.tempsAsInputTypeTime;
    } else if(dto !== null && dto !== undefined){
      if((dto as any)?.resetTypeTache !== undefined)this.resetTypeTache = (dto as any).resetTypeTache;
      if((dto as any)?.resetCommanditaire !== undefined)this.resetCommanditaire = (dto as any).resetCommanditaire;
      if((dto as any)?.resetApplication !== undefined)this.resetApplication = (dto as any).resetApplication;
      if((dto as any)?.resetModule !== undefined)this.resetModule = (dto as any).resetModule;
      if((dto as any)?.initAtLastDate !== undefined)this.initAtLastDate = (dto as any).initAtLastDate;
      if((dto as any)?.tempsAsInputTypeTime !== undefined)this.tempsAsInputTypeTime = (dto as any).tempsAsInputTypeTime;
    }
  }
}
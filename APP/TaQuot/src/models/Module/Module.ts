export default class ModuleDTO{
    id = '';
    libelle = '';
    applicationId = '';
}

export class Module extends ModuleDTO{

    public constructor(dto : ModuleDTO | null = null){
        super();

        if(dto?.id){
            this.id = dto.id;
        }
        if(dto?.libelle){
            this.libelle = dto.libelle;
        }
        if(dto?.applicationId){
            this.applicationId = dto.applicationId;
        }
    }

}
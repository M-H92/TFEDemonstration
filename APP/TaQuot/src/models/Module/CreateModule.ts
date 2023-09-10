export default class CreateModuleDTO{
    libelle = '';
    applicationId = '';
    commanditaireId= '';
}

export class CreateModule extends CreateModuleDTO{

    public constructor(dto : CreateModuleDTO | null = null){
        super();

        if(dto?.commanditaireId){
            this.commanditaireId = dto.commanditaireId;
        }
        if(dto?.libelle){
            this.libelle = dto.libelle;
        }
        if(dto?.applicationId){
            this.applicationId = dto.applicationId;
        }
    }

}
export default class CommanditaireDTO{
    id = '';
    nom = ''
}

export class Commanditaire extends CommanditaireDTO{

    public constructor(dto : CommanditaireDTO | null = null){
        super();

        if(dto?.id){
            this.id = dto.id;
        }
        
        if(dto?.nom){
            this.nom = dto.nom;
        }
    }

}
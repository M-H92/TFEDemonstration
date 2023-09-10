export default class TypeTacheDTO {
    id = '';
    libelle = '';
}

export class TypeTache extends TypeTacheDTO {
    
    
    public constructor(dto : TypeTacheDTO | null = null){
        super();

        if(dto?.id){
            this.id = dto.id;
        }
        
        if(dto?.libelle){
            this.libelle = dto.libelle;
        }
    }
}
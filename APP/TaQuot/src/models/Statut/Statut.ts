export default class StatutDTO {
    id = '';
    libelle = '';
}

export class Statut extends StatutDTO {
    
    
    public constructor(dto : StatutDTO | null = null){
        super();
        if(dto !== null) Object.assign(this, dto);
    }
}
export default class RoleDescriptionDTO{
    role = '';
    description = '';
}

export class RoleDescription extends RoleDescriptionDTO {
    constructor(dto : RoleDescriptionDTO | null){
        super();
        if(dto){
            this.role = dto.role;
            this.description = dto.description;
        }
    }

    get libelleFull(){
        return `${this.role} - ${this.description}`
    }
}
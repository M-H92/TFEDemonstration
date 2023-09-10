export default class RoleCollaborateurDTO {
    role = '';
    collaborateur = '';
}

export class RoleCollaborateur extends RoleCollaborateurDTO {
    constructor(dto : RoleCollaborateurDTO | null){
        super();
        if(dto){
            this.role = dto.role;
            this.collaborateur = dto.collaborateur;
        }
    }
}
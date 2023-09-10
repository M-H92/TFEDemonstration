import { RoleDescription } from "./RoleDescription";

export default class CollaborateurDTO{
    collaborateur = '';
}

export class Collaborateur extends CollaborateurDTO {
    roles = [] as RoleDescription[];

    constructor(dto = null as CollaborateurDTO | null){
        super();
        if(dto){
            this.collaborateur = dto.collaborateur;
        }
    }

    public addRole(role : RoleDescription | RoleDescription[]){
        if(!role) return;
        const inputRole = [] as RoleDescription[];
        
        if(role instanceof RoleDescription)
            inputRole.push(role);
        else inputRole.push(...role);

        const rolesToAdd = [] as RoleDescription[];
        inputRole.forEach(i => {
            if(!this.roles.some(r => r.role === i.role))
                rolesToAdd.push(i);
        });
        this.roles.push(...rolesToAdd);
    }

    public hasRole(role : RoleDescription | string){
        if(role instanceof RoleDescription)
            return this.roles.some(r => r.role === role.role);
        if(typeof(role) === 'string')
            return this.roles.some(r => r.role === role);
        return false;
    }
}
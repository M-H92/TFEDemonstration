using Contracts.IRepositories;
using Entities.Models;
using Service.Contracts.Admin;
using Shared.DataTransfertObject.Admin.Permissions;

namespace Service.Admin
{
    internal sealed class AdminPermissionService : IAdminPermissionService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AdminPermissionService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public IEnumerable<CollaborateursDTO> GetCollaborateur()
            => this._repositoryManager.RoleUtilisateur.GetUsers(trackChanges: false).Select(u => new CollaborateursDTO(u));

        public IEnumerable<RoleDescriptionDTO> GetRole()
            => this._repositoryManager.Role.GetRoles(tranckChanges: false).Select(r => new RoleDescriptionDTO(r.Label, r.Description));

        public IEnumerable<RoleCollaborateurDTO> GetRoleCollaborateur()
            => this._repositoryManager.RoleUtilisateur.GetAll(trackChanges: false).Select(ru => new RoleCollaborateurDTO(ru.RoleId, ru.Utilisateur));

        public void CreateCollaborateursRoles(CreateCollaborateursRolesDTO dto)
        {
            List<RoleUtilisateur> rolesUtilisateurs = new();
            List<RoleUtilisateur> rolesUtilisateursToAdd = new();
            foreach (var collaborateur in dto.Collaborateurs.Distinct())
                rolesUtilisateurs.AddRange(dto.Roles.Distinct().Select(r => new RoleUtilisateur { RoleId = r, Utilisateur = collaborateur }));

            foreach (RoleUtilisateur ru in rolesUtilisateurs)
                if (this._repositoryManager.RoleUtilisateur.Get(ru, tranckChanges: false) is null)
                    rolesUtilisateursToAdd.Add(ru);

            this._repositoryManager.RoleUtilisateur.CreateRange(rolesUtilisateursToAdd);
            this._repositoryManager.Save();
        }
        public void DeleteCollaborateursRoles(CreateCollaborateursRolesDTO dto)
        {
            List<RoleUtilisateur> rolesUtilisateurs = new();
            List<RoleUtilisateur> rolesUtilisateursToDelete = new();
            foreach (var collaborateur in dto.Collaborateurs.Distinct())
                rolesUtilisateurs.AddRange(dto.Roles.Distinct().Select(r => new RoleUtilisateur { RoleId = r, Utilisateur = collaborateur }));

            foreach (RoleUtilisateur ru in rolesUtilisateurs)
                if (this._repositoryManager.RoleUtilisateur.Get(ru, tranckChanges: false) is not null)
                    rolesUtilisateursToDelete.Add(ru);

            this._repositoryManager.RoleUtilisateur.DeleteRange(rolesUtilisateursToDelete);
            this._repositoryManager.Save();
        }

    }
}

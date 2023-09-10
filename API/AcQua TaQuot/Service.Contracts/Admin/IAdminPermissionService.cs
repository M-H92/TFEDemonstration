using Shared.DataTransfertObject.Admin.Permissions;

namespace Service.Contracts.Admin
{
    public interface IAdminPermissionService
    {
        IEnumerable<RoleCollaborateurDTO> GetRoleCollaborateur();
        IEnumerable<CollaborateursDTO> GetCollaborateur();
        IEnumerable<RoleDescriptionDTO> GetRole();
        void CreateCollaborateursRoles(CreateCollaborateursRolesDTO dto);
        void DeleteCollaborateursRoles(CreateCollaborateursRolesDTO dto);
    }
}

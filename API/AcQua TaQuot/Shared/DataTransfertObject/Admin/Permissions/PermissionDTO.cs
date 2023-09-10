namespace Shared.DataTransfertObject.Admin.Permissions
{
    public record RoleCollaborateurDTO(string Role, string Collaborateur);
    public record CollaborateursDTO(string Collaborateur);
    public record RoleDescriptionDTO(string Role, string Description);
    public record CreateCollaborateursRolesDTO(List<string> Roles, List<string> Collaborateurs);
}

using Contracts.IRepositories;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransfertObject.Token;

namespace Service
{
    internal sealed class PermissionService : IPermissionService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PermissionService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public string GetRolesToken(string user, IJWTService jwtService)
        {
            var roles = this._repositoryManager.RoleUtilisateur.GetForUser(user, tranckChanges: false).Select(ru => ru.RoleId).ToList();
            if (roles.Count is 0)
                roles.Add(this.GiveRoleDefaut(user));
            var createRoleTokenDTO = new CreateRoleTokenDTO(user, roles);
            return jwtService.GenerateRoleToken(createRoleTokenDTO);
        }
        private string GiveRoleDefaut(string user)
        {
            var defaultRole = new RoleUtilisateur() { RoleId = "DEFAUT", Utilisateur = user };
            this._repositoryManager.RoleUtilisateur.Create(defaultRole);
            this._repositoryManager.Save();
            return defaultRole.RoleId;
        }
    }
}

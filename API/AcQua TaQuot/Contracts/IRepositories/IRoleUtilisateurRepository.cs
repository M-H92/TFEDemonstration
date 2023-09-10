using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IRoleUtilisateurRepository
    {
        public IEnumerable<RoleUtilisateur> GetForUser(string user, bool tranckChanges);
        public IEnumerable<RoleUtilisateur> GetForRole(string role, bool tranckChanges);
        public RoleUtilisateur? Get(RoleUtilisateur entity, bool tranckChanges);
        public RoleUtilisateur? Get(string role, string user, bool tranckChanges);
        public IEnumerable<string> GetUsers(bool trackChanges);
        public IEnumerable<RoleUtilisateur> GetAll(bool trackChanges);
        public void UpdateRange(IEnumerable<RoleUtilisateur> entities);
        public void CreateRange(IEnumerable<RoleUtilisateur> entities);
        public void Create(RoleUtilisateur entity);
        public void DeleteRange(IEnumerable<RoleUtilisateur> entities);
    }
}

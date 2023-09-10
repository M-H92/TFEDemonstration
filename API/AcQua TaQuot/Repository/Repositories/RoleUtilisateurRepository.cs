using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class RoleUtilisateurRepository : RepositoryBase<RoleUtilisateur>, IRoleUtilisateurRepository
    {
        public RoleUtilisateurRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public RoleUtilisateur? Get(RoleUtilisateur roleUtilisateur, bool tranckChanges)
            => this.Get(roleUtilisateur.RoleId, roleUtilisateur.Utilisateur, tranckChanges);
        public RoleUtilisateur? Get(string role, string user, bool tranckChanges)
            => this.ReadWhere(r => r.RoleId.Equals(role) && r.Utilisateur.Equals(user), tranckChanges).FirstOrDefault();

        public IEnumerable<RoleUtilisateur> GetForRole(string role, bool tranckChanges)
            => this.ReadWhere(r => r.RoleId.Equals(role), tranckChanges);

        public IEnumerable<RoleUtilisateur> GetForUser(string user, bool tranckChanges)
            => this.ReadWhere(r => r.Utilisateur.Equals(user), tranckChanges);

        public IEnumerable<string> GetUsers(bool trackChanges)
            => this.ReadAll(trackChanges).Select(ru => ru.Utilisateur).Distinct();
        public IEnumerable<RoleUtilisateur> GetAll(bool trackChanges)
            => this.ReadAll(trackChanges);

    }
}

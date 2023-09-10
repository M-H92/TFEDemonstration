using Entities.Models;
using System.Linq.Expressions;

namespace Contracts.IRepositories
{
    public interface ITacheRepository
    {
        public void CreateTache(Tache entity);
        public Tache? Get(Guid id, bool trackChanges);
        public IQueryable<Tache> ReadWhere(Expression<Func<Tache, bool>> expression, bool trackChanges);

    }
}

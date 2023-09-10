using System.Linq.Expressions;

namespace Contracts.IRepositories
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        IQueryable<T> ReadAll(bool trackChanges);
        IQueryable<T> ReadWhere(Expression<Func<T, bool>> expression, bool trackChanges);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
    }
}

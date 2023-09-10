using Entities.Models;
using System.Linq.Expressions;

namespace Contracts.IRepositories
{
    public interface IPrestationRepository
    {
        public void CreatePrestation(Prestation prestation);
        public List<Prestation> GetPrestations(int take, int skip, string user);
        public IQueryable<Prestation> ReadWhere(Expression<Func<Prestation, bool>> expression, bool trackChanges);

        /// <summary> Where params "from" and "to" are inclusives</summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public List<Prestation> GetPrestations(DateTime from, DateTime to);
        public List<Prestation> GetFacturable(DateTime from, DateTime to);
        public Prestation? Get(Guid id, bool trackChanges);
        public Prestation? GetDetails(Guid id, bool trackChanges);
        public void Delete(Prestation prestation);
        public int GetNextDisplayNumber(DateTime datePrestation);
        void Update(Prestation entity);
        void UpdateRange(IEnumerable<Prestation> entities);
    }
}

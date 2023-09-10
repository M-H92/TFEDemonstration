using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IStatutRepository
    {
        IEnumerable<Statut> GetAllStatut(bool trackChanges);
        Statut? Get(Guid statutId, bool trackChanges);
        Statut GetDefaultFacturableStatut(bool trackChanges);
        Statut GetDefaultNonFacturableStatut(bool trackChanges);
        /// <summary>Récupère les statuts pour lesquels les prestations ne peuvent plus être modifées</summary>
        IEnumerable<Statut> GetDefaultUntouchablesStatuts();
    }
}

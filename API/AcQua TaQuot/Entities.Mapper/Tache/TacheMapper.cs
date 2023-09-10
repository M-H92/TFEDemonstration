using Entities.Models;
using Shared.DataTransfertObject;

namespace Entities.Mapper
{
    public static partial class TacheMapper
    {
        public static Tache ToTache(this CreatePrestationDTO dto, Guid prestationId)
        {
            return new Tache()
            {
                Libelle = dto.Tache,
                ModuleId = dto.ModuleId,
                PrestationId = prestationId
            };
        }
    }
}

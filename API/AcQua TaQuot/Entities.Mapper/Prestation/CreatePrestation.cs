using Entities.Models;
using Shared.DataTransfertObject;

namespace Entities.Mapper
{
    public static partial class PrestationMapper
    {
        public static Prestation ToPrestation(this CreatePrestationDTO dto, Guid statutId, int displayNumber)
        {
            return new Prestation()
            {
                IssueGitLab = -1, //TODO modifier lors de la gestion gitlab
                Commentaire = dto.Commentaire,
                Date = dto.Date,
                Temps = dto.Temps,
                //Par défaut, lors de la création par un collaborateur, true.
                //Plus tard, modifiable par l'administrateur ou set par rapport au type/client
                IsFacturable = true,
                Utilisateur = dto.Utilisateur,
                TypeTacheId = dto.TypeTacheId,
                StatutId = statutId,
                DisplayNumber = displayNumber
            };
        }
    }
}

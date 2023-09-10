using Entities.Models;
using Shared.DataTransfertObject;

namespace Entities.Mapper
{
    public static partial class PrestationMapper
    {
        public static PrestationDTO ToPrestationDTO(this Prestation entity)
        {
            return new PrestationDTO(entity.Id, entity.IssueGitLab, entity.Commentaire, entity.Date, entity.Temps, entity.IsFacturable, entity.Utilisateur, entity.TypeTacheId, entity.StatutId);
        }

        public static Prestation Update(this Prestation entity, UpdatePrestationDTO dto)
        {
            //entity.IssueGitLab
            entity.Commentaire = dto.Commentaire;
            entity.Date = dto.Date;
            entity.Temps = dto.Temps;
            //entity.IsFacturable
            //entity.Utilisateur
            entity.TypeTacheId = dto.TypeTacheId;
            //entity.StatutId 

            return entity;
        }

    }
}

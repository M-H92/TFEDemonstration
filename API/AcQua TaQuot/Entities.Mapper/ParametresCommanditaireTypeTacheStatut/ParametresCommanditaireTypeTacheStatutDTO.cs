using Entities.Models;
using Shared.DataTransfertObject.ParametresCommanditaireTypeTacheStatut;

namespace Entities.Mapper
{
    public static class ParametresCommanditaireTypeTacheStatutMapper
    {
        public static ParametresCommanditaireTypeTacheStatut ToEntity(this ParametresCommanditaireTypeTacheStatutDTO dto)
        => new() { CommanditaireId = dto.CommanditaireId, TypeTacheId = dto.TypeTacheId, StatutId = dto.StatutDefautId };

        public static ParametresCommanditaireTypeTacheStatutDTO ToDTO(this ParametresCommanditaireTypeTacheStatut entity)
        => new ParametresCommanditaireTypeTacheStatutDTO() { CommanditaireId = entity.CommanditaireId, StatutDefautId = entity.StatutId, TypeTacheId = entity.TypeTacheId };
    }
}

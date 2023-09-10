using Entities.Models;
using Shared.DataTransfertObject;

namespace Entities.Mapper
{
    public static partial class CommanditaireMapper
    {
        public static Commanditaire ToEntity(this CreateCommanditaireDTO dto)
        {
            Commanditaire entity = new();
            entity.Nom = dto.Nom;

            return entity;
        }
    }
}

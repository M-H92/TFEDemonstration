using Entities.Models;
using Shared.DataTransfertObject;

namespace Entities.Mapper
{
    public static partial class CommanditaireMapper
    {
        public static CommanditaireDTO ToCommanditaireDTO(this Commanditaire entity)
        {
            return new CommanditaireDTO(entity.Id, entity.Nom);
        }
    }
}

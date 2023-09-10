using Entities.Models.userPreferences;
using Shared.DataTransfertObject.Prestation;

namespace Entities.Mapper.UserPreferences
{
    public static partial class PreferenceEncodagePrestationMappers
    {
        public static PreferenceEncodagePrestation ToEntity(this PutPreferenceEncodagePrestationDTO dto)
        {
            PreferenceEncodagePrestation output = new();
            output.Utilisateur = dto.User;
            output.ResetTypeTache = dto.ResetTypeTache;
            output.ResetCommanditaire = dto.ResetCommanditaire;
            output.ResetApplication = dto.ResetApplication;
            output.ResetModule = dto.ResetModule;
            output.InitAtLastDate = dto.InitAtLastDate;
            output.TempsAsInputTypeTime = dto.TempsAsInputTypeTime;

            return output;
        }

        public static GetPreferenceEncodagePrestationDTO ToDTO(this PreferenceEncodagePrestation entity)
            => new(entity.ResetTypeTache, entity.ResetCommanditaire, entity.ResetApplication, entity.ResetModule, entity.InitAtLastDate, entity.TempsAsInputTypeTime);
    }
}

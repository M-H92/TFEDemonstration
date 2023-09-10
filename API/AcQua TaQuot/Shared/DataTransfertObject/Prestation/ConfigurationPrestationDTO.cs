namespace Shared.DataTransfertObject.Prestation
{
    public record PutPreferenceEncodagePrestationDTO(string User, bool ResetTypeTache, bool ResetCommanditaire, bool ResetApplication, bool ResetModule, bool InitAtLastDate, bool TempsAsInputTypeTime);
    public record GetPreferenceEncodagePrestationDTO(bool ResetTypeTache, bool ResetCommanditaire, bool ResetApplication, bool ResetModule, bool InitAtLastDate, bool TempsAsInputTypeTime);
}

namespace Shared.DataTransfertObject
{
    public record ApplicationCommanditaireDTO(Guid Id, string Libelle, Guid CommanditaireId);
    public record CreateApplicationDTO(string Libelle, Guid CommanditaireId);
}

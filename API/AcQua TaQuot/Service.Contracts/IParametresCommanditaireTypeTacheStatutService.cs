using Shared.DataTransfertObject.ParametresCommanditaireTypeTacheStatut;

namespace Service.Contracts
{
    public interface IParametresCommanditaireTypeTacheStatutService
    {
        Task<List<ParametresCommanditaireTypeTacheStatutDTO>> GetParametresCommanditaireTypeTacheStatut(Guid? commanditaire, Guid? typeTache, Guid? statut, int skip, int take);
        Task<ParametresCommanditaireTypeTacheStatutDTO> GetParametresCommanditaireTypeTacheStatut(Guid commanditaire, Guid typeTache);
        Task AddParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto);
        Task UpdateParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto);
        Task DeleteParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto);
    }
}

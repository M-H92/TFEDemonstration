using Shared.DataTransfertObject;
using Shared.DataTransfertObject.Prestation;

namespace Service.Contracts
{
    public interface IPrestationService
    {
        public PrestationDTO Create(CreatePrestationDTO dto);
        public DetailPrestationDTO Get(Guid id, bool trackChanges = false);
        public List<PaginatePrestationDTO> GetPaginatedPrestations(int take, int skip, string user);
        public List<PaginatePrestationDTO> GetTodaysPrestations(string user);
        public void Delete(Guid id);
        public void Update(Guid id, UpdatePrestationDTO dto);
        public void UpdateConfigurationPrestation(PutPreferenceEncodagePrestationDTO dto);
        public GetPreferenceEncodagePrestationDTO GetPreferenceUtilisateur(string user);
    }
}

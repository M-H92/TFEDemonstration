using Shared.DataTransfertObject.Token;

namespace Service.Contracts
{
    public interface IJWTService
    {
        public string GenerateRoleToken(CreateRoleTokenDTO dto);
    }
}

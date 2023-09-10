namespace TaQuotAuth.DTO
{
    public record PostConnectDTO(string identifier, string password);
    public record PostConnectDTOResponse(string jwtoken);
}

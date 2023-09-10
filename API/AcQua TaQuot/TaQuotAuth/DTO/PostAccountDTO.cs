namespace TaQuotAuth.DTO
{
    public record PostAccountDTO(string identifier, string password, string passwordValidation);
    public record PostAccountDTOResponse(string jwtoken);
}

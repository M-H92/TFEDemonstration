using Microsoft.AspNetCore.Mvc;
using TaQuotAuth.DTO;
using TaQuotAuth.Repository;
using TaQuotAuth.Utils;

namespace TaQuotAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TaQuotAuthContext context;

        public AuthenticationController(TaQuotAuthContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Connect([FromBody] PostConnectDTO dto)
        {
            try
            {
                var account = this.context.UserAccount.FirstOrDefault(u => u.Identifier == dto.identifier);
                if (account is null)
                    throw new Exception();
                if (!HashingUtils.VerifyHashedPassword(account.Password, dto.password))
                    throw new Exception();
                return Ok(JWTUtils.GenerateToken(account.Identifier));
            }
            catch (Exception)
            {
                return BadRequest("Mot de passe ou identifiant invalide");
            }
        }
    }
}

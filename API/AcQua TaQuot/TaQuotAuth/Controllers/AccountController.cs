using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TaQuotAuth.DTO;
using TaQuotAuth.Repository;
using TaQuotAuth.Repository.Entities;
using TaQuotAuth.Utils;

namespace TaQuotAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TaQuotAuthContext context;

        public AccountController(TaQuotAuthContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AccountCreation([FromBody] PostAccountDTO dto)
        {
            if (dto.identifier.Length is not 3)
                return BadRequest("Identifiant invalide");
            if (dto.password != dto.passwordValidation)
                return BadRequest("Les deux mots de passe ne sont pas identiques");
            var passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (!passwordRegex.IsMatch(dto.password))
                return BadRequest("Le mot de passe n'est pas assez fort");

            var hashedPassword = HashingUtils.HashPassword(dto.password);

            var entity = new EntityUserAccount()
            {
                Identifier = dto.identifier,
                Password = hashedPassword
            };

            if (this.context.UserAccount.FirstOrDefault(a => a.Identifier == entity.Identifier) is not null)
                return BadRequest($"l'identifiant {entity.Identifier} est déjà utilisé par l'utilisateur {entity.Identifier}");
            //Note pour la présentation de TFE => Je sais que le message d'erreur précédent est redondant dans sa formulation.
            //Mais je sais que mes collègues vont vouloir essayer et il est redondant spécialement pour eux

            try
            {
                this.context.Add(entity);
                await this.context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok();
        }



    }
}

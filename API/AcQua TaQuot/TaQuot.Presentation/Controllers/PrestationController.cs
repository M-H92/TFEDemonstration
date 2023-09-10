using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject;
using Shared.DataTransfertObject.Prestation;
using System.Security.Claims;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class PrestationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PrestationController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        #region Get

        [HttpGet]
        public IActionResult GetPrestation([FromQuery] ParamsPaginationPrestationDTO args)
        {
            if (args.PageSize <= 0) throw new Exception($"param PageSize de valeur : {args.PageSize} doit être strictement positif.");
            if (args.PageNumber < 0) throw new Exception($"param PageNumber de valeur : {args.PageNumber} doit être strictitement positif.");
            if (string.IsNullOrEmpty(args.User)) throw new Exception($"Impossible de récupérer les prestations pour l'utilisateur : {args.User}");

            return Ok(this._serviceManager.PrestationService.GetPaginatedPrestations(args.PageSize, args.PageNumber - 1, args.User));
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Ok(this._serviceManager.PrestationService.Get(id));
        }

        [HttpGet("Configuration")]
        public IActionResult GetPreferenceUtilisateur([FromQuery] string User)
        {
            return Ok(this._serviceManager.PrestationService.GetPreferenceUtilisateur(User));
        }

        [HttpGet("Today")]
        public IActionResult GetToday([FromServices] IJWTService jwtService)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            if (string.IsNullOrEmpty(username))
                return BadRequest("Impossible d'authentifier l'utilisateur");
            return Ok(this._serviceManager.PrestationService.GetTodaysPrestations(username));
        }
        #endregion

        #region Post

        [HttpPost]
        public IActionResult PostPrestation(CreatePrestationDTO prestation)
        {
            return Ok(this._serviceManager.PrestationService.Create(prestation));
        }

        #endregion

        #region Put

        [HttpPut("{id:guid}")]
        public IActionResult PutPrestation(Guid id, [FromBody] UpdatePrestationDTO prestation)
        {
            if (prestation is null)
                return BadRequest("Le Taquot fourni pour la modification est vide");

            this._serviceManager.PrestationService.Update(id, prestation);
            return NoContent();
        }

        [HttpPut("Configuration")]
        public IActionResult putConfiguration([FromBody] PutPreferenceEncodagePrestationDTO preferences)
        {
            this._serviceManager.PrestationService.UpdateConfigurationPrestation(preferences);
            return NoContent();
        }
        #endregion

        #region Delete

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePrestation(Guid id)
        {
            this._serviceManager.PrestationService.Delete(id);
            return NoContent();
        }

        #endregion
    }
}

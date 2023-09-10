using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.ParametresCommanditaireTypeTacheStatut;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ParametresCommanditaireTypeTacheStatutController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ParametresCommanditaireTypeTacheStatutController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetParametresCommanditaireTypeTacheStatut([FromQuery] ParametresCommanditaireTypeTacheStatutGetDTO dto)
        {
            dto.CommanditaireId = dto.CommanditaireId == default(Guid) ? null : dto.CommanditaireId;
            dto.TypeTacheId = dto.TypeTacheId == default(Guid) ? null : dto.TypeTacheId;
            dto.StatutDefautId = dto.StatutDefautId == default(Guid) ? null : dto.StatutDefautId;

            var result = await this._serviceManager.ParametresCommanditaireTypeTacheStatutService.GetParametresCommanditaireTypeTacheStatut(dto.CommanditaireId, dto.TypeTacheId, dto.StatutDefautId, dto.Skip, dto.Take);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostParametresCommanditaireTypeTacheStatut([FromBody] ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            await this._serviceManager.ParametresCommanditaireTypeTacheStatutService.AddParametresCommanditaireTypeTacheStatut(dto);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> PutParametresCommanditaireTypeTacheStatut([FromBody] ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            await this._serviceManager.ParametresCommanditaireTypeTacheStatutService.UpdateParametresCommanditaireTypeTacheStatut(dto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteParametresCommanditaireTypeTacheStatut([FromQuery] ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            await this._serviceManager.ParametresCommanditaireTypeTacheStatutService.DeleteParametresCommanditaireTypeTacheStatut(dto);
            return NoContent();
        }
    }
}

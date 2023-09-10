using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class CommanditaireController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CommanditaireController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCommanditaire()
        {
            var results = this._serviceManager.CommanditaireService.Get(false);
            return Ok(results);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCommanditaire(Guid id)
        {
            var result = this._serviceManager.CommanditaireService.Get(id, false);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostCommanditaire(CreateCommanditaireDTO commanditaire)
        {
            return Ok(this._serviceManager.CommanditaireService.Create(commanditaire));
        }
    }
}

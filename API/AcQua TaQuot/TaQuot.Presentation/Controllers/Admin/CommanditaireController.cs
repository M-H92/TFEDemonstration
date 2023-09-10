using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,NIVEAUSUP")]
    [ApiController]
    public class CommanditaireController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CommanditaireController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }


        [HttpPost]
        public IActionResult PostCommanditaire(CreateCommanditaireDTO commanditaire)
        {
            return Ok(this._serviceManager.CommanditaireService.Create(commanditaire));
        }
    }
}

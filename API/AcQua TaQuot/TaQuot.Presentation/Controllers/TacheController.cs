using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class TacheController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TacheController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost]
        public IActionResult PostTaQuot(CreateTaQuotDTO taQuot)
        {
            return Ok();
            //return Ok(this._serviceManager.CommanditaireService.Create(commanditaire));
        }
    }
}

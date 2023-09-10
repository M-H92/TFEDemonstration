using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ApplicationsController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet("Commanditaires")]
        public IActionResult GetApplicationClient()
        {
            var result = this._serviceManager.ApplicationService.GetApplicationCommanditaire(tranckChanges: false);
            return Ok(result);
        }
    }
}

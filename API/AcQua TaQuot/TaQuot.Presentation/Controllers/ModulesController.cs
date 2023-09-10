using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ModulesController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet("Application")]
        public IActionResult GetModuleApplication()
        {
            var result = this._serviceManager.ModuleService.GetModuleApplication(tracking: false);
            return Ok(result);
        }
    }
}

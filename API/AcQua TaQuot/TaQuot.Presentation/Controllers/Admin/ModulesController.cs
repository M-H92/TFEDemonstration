using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Module;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,NIVEAUINF")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ModulesController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost]
        public IActionResult PostModule(CreateModuleDTO dto)
        {
            this._serviceManager.ModuleService.PostModule(dto);
            return NoContent();
        }
    }
}

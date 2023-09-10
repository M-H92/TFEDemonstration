using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,NIVEAUMOY")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ApplicationsController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }


        [HttpPost]
        public IActionResult PostApplication(CreateApplicationDTO dto)
        {
            this._serviceManager.ApplicationService.PostApplication(dto);
            return NoContent();
        }
    }
}

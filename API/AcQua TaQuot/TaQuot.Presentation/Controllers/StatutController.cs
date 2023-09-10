using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class StatutController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public StatutController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        #region GET

        [HttpGet]
        public IActionResult GetAllStatut()
        {
            var statuts = this._serviceManager.StatutService.GetAllStatut(tranckChanges: false);
            return Ok(statuts);
        }

        #endregion
    }
}

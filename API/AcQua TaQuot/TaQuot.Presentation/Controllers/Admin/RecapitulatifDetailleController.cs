using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,STATS")]
    [ApiController]
    public class RecapitulatifDetailleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public RecapitulatifDetailleController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetRecapitulatifDetailleStats([FromQuery] int backwardMonths)
        {
            return Ok(this._serviceManager.RecapitulatifDetailleService.GetRecapitulatifDetailleStats(backwardMonths));
        }

        [HttpGet("JoursPrestes")]
        public IActionResult GetJoursPrestes([FromQuery] int backwardMonths)
        {
            return Ok(this._serviceManager.RecapitulatifDetailleService.GetJoursPrestes(backwardMonths));
        }
    }
}

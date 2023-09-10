using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,RECAP")]
    [ApiController]
    public class RecapController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public RecapController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet("Week/{week:datetime}")]
        public IActionResult GetApplicationClient(string week)
        {
            var startDate = DateTime.ParseExact(week, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return Ok(this._serviceManager.RecapService.GetWeeklyRecaps(startDate));
        }
    }
}

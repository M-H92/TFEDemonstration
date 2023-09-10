using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class TypeTacheController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TypeTacheController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        #region GET

        [HttpGet]
        public IActionResult GetAllTypeTache()
        {
            var typeTaches = this._serviceManager.TypeTacheService.GetAllTypeTache(tranckChanges: false);
            //var statuts = this._serviceManager.StatutService.GetAllStatut(tranckChanges: false);
            return Ok(typeTaches);
        }

        #endregion
    }
}

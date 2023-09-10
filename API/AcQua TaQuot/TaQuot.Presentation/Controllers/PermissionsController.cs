using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Security.Claims;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    [Authorize]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PermissionsController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetRoleToken([FromServices] IJWTService jwtService)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            if (string.IsNullOrEmpty(username))
                return BadRequest("Impossible d'authentifier l'utilisateur");
            var result = this._serviceManager.PermissionService.GetRolesToken(username, jwtService);
            return Ok(result);
        }
    }
}

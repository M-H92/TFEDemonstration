using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Admin.Permissions;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PermissionsController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(this._serviceManager.AdminPermissionService.GetRole());
        }

        [HttpGet("Collaborateurs")]
        public IActionResult GetCollaborateurs()
        {
            return Ok(this._serviceManager.AdminPermissionService.GetCollaborateur());
        }

        [HttpGet("RolesCollaborateurs")]
        public IActionResult GetRolesCollaborateurs()
        {
            return Ok(this._serviceManager.AdminPermissionService.GetRoleCollaborateur());
        }

        [HttpPost("RolesCollaborateurs")]
        public IActionResult PostRolesCollaborateurs([FromBody] CreateCollaborateursRolesDTO dto)
        {
            this._serviceManager.AdminPermissionService.CreateCollaborateursRoles(dto);
            return Ok();
        }

        [HttpDelete("RolesCollaborateurs")]
        public IActionResult DeleteRolesCollaborateurs([FromBody] CreateCollaborateursRolesDTO dto)
        {
            this._serviceManager.AdminPermissionService.DeleteCollaborateursRoles(dto);
            return Ok();
        }
    }
}

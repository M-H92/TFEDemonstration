using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.SprintReview;

namespace TaQuot.Presentation.Controllers.Admin
{
    [Route("Admin/Taquot/[controller]")]
    [Authorize(Roles = "ADMIN,STATS")]
    [ApiController]
    public class SprintReviewController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public SprintReviewController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost]
        public IActionResult GetSprintReviewStats([FromBody] ParamsGetSprintReviewStatDTO paramsDTO)
        {
            if (paramsDTO.Collaborateurs.Count is 0)
                return BadRequest("Au moins un collaborateur doit être sélectionné");
            if (paramsDTO.Collaborateurs.Any(c => c.Length is not 3))
                return BadRequest("Les collaborateurs doivent être représentés par des trigrammes");
            if (paramsDTO.DateDebut >= DateTime.Now)
                return BadRequest("La date de début doit être inférieur à la date du jour");
            if (paramsDTO.DateFin <= paramsDTO.DateDebut)
                return BadRequest("La date de fin doit être postérieur à la date de début");

            return Ok(this._serviceManager.SprintReviewService.GetSprintReviewStats(paramsDTO.Collaborateurs, paramsDTO.DateDebut, paramsDTO.DateFin));
        }
    }
}

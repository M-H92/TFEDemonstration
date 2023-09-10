using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfertObject.Facturation;
using System.Net;
using System.Net.Http.Headers;

namespace TaQuot.Presentation.Controllers
{
    [Route("Taquot/[controller]")]
    //[Authorize(Roles = "FACTURATION")]
    [ApiController]
    public class FacturationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FacturationController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpGet("Facturable")]
        public IActionResult GetFacturable([FromQuery] DateTime dateDebut, [FromQuery] DateTime dateFin)
        {
            if (dateDebut > dateFin)
                return BadRequest("La date de début doit être inférieure ou égale à la date de fin");

            return Ok(this._serviceManager.FacturationService.GetLignesFacturables(dateDebut, dateFin));
        }
        [HttpGet]
        public IActionResult test([FromQuery] DateTime dateDebut, [FromQuery] DateTime dateFin)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write("Hello, World!");
            writer.Flush();
            stream.Position = 0;

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(stream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return File(stream, "text/csv", "test.csv");
        }

        [HttpPost("Facturable/Export")]
        public IActionResult ExportFacturable([FromBody] ExportableLigneFacturableDTO dto)
        {
            if (dto.DateDebut == default) return BadRequest("Date de début invalide");
            if (dto.DateFin == default) return BadRequest("Date de fin invalide");
            if (dto.DateDebut > dto.DateFin) return BadRequest("La date de début doit être inférieure ou égale à la date de fin");
            if (dto.ligneFacturableDTOs is null || dto.ligneFacturableDTOs.Count is 0) return BadRequest("Pas de ligne à analyser");
            if (dto.ligneFacturableDTOs.Any(l => default == l.ModuleId)) return BadRequest("Un module renseigné est invalide");
            if (dto.ligneFacturableDTOs.Any(l => default == l.TypeTacheId)) return BadRequest("Un type de tache renseigné est invalide");
            if (dto.ligneFacturableDTOs.Any(l => default == l.StatutId)) return BadRequest("Un Statut renseigné est invalide");
            if (dto.ligneFacturableDTOs.Any(l => string.IsNullOrEmpty(l.Tache))) return BadRequest("Une tâche renseignée est invalide");

            var file = this._serviceManager.FacturationService.ExportFacturableToCSV(dto);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(file);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return File(file, "text/csv", "test.csv");
        }
    }
}

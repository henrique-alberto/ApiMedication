using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ApiMedication.Controllers
{
    [Route("api/medication")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MedicationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMedications()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddMedication()
        {
            return Ok();
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteMedication()
        {
            return NoContent();
        }
    }
}

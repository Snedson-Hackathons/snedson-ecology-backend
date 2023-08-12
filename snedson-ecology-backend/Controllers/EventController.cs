using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace snedson_ecology_backend.Controllers
{
    [Route("/api/events")]
    [ApiController]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Events(int limit, int offset)
        {
            return Ok("Hej");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            return Ok("Hej " + id.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent()
        {
            return Ok("Hej");
        }

    }
}

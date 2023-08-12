using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace snedson_ecology_backend.Controllers
{
    [Route("/api")]
    [ApiController]
    public class EventController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Events(int take, int offset)
        {
            //MainPageRM toReturn = await _mainPageFiller.FillModel(StudentId);
            return Ok("Hej");
        }

        [HttpGet("event")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            //MainPageRM toReturn = await _mainPageFiller.FillModel(StudentId);
            return Ok("Hej");
        }

        [HttpPost("event")]
        public async Task<IActionResult> CreateEvent(Guid id)
        {
            //MainPageRM toReturn = await _mainPageFiller.FillModel(StudentId);
            return Ok("Hej");
        }

    }
}

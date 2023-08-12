using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using snedson_ecology_backend.core.Actions.EventActions;

namespace snedson_ecology_backend.Controllers
{
    [Route("/api/v1/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly GetEventByIdAction getEventById;

        public EventController(GetEventByIdAction getEventById)
        {
            this.getEventById = getEventById;
        }

        [HttpGet]
        public async Task<IActionResult> Events(int limit, int offset)
        {
            return Ok("Hej");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            return Ok(await getEventById.Action(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent()
        {
            return Ok("Hej");
        }

    }
}

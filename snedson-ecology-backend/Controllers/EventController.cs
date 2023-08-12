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
        private readonly GetEventsAction getEvents;

        public EventController(GetEventByIdAction getEventById, GetEventsAction getEvents)
        {
            this.getEventById = getEventById;
            this.getEvents = getEvents;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents(int limit, int offset)
        {
            return Ok(await getEvents.Action(limit, offset));
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

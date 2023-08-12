using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using snedson_ecology_backend.core.Actions.EventActions;
using snedson_ecology_backend.core.Models.Dtos;

namespace snedson_ecology_backend.Controllers
{
    [Route("/api/v1/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly GetEventByIdAction getEventById;
        private readonly GetEventsAction getEvents;
        private readonly CreateEventAction createEvent;

        public EventController
            (GetEventByIdAction getEventById, 
            GetEventsAction getEvents,
            CreateEventAction createEvent)
        {
            this.getEventById = getEventById;
            this.getEvents = getEvents;
            this.createEvent = createEvent;
        }

        public Guid UserId
        {
            get => Guid.Parse("29e25ed3-d9b8-4d01-8c20-5bbe3e9c02a3"); // Temporary
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
        public async Task<IActionResult> CreateEvent([FromBody]EventDto eventAction)
        {
            return Ok(await createEvent.Action(eventAction, UserId));
        }
    }
}

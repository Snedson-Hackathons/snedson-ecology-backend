using MediatR;
using snedson_ecology_backend.core.Features.Commands.EventCommands;
using snedson_ecology_backend.core.Models.Dtos;
using snedson_ecology_backend.core.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Actions.EventActions
{
    public class CreateEventAction : AbstractAction
    {
        public CreateEventAction(IMediator mediator) : base(mediator)
        { }

        public async Task<CreateEventRm> Action(EventDto requestEvent, Guid authorGuid)
        {
            return new CreateEventRm
            {
                CreatedEventId = await _mediator.Send(new CreateEventCommand { EventModel = requestEvent, AuthorId = authorGuid })
            };
        }
    }
}

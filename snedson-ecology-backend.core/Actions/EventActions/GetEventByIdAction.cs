using MediatR;
using snedson_ecology_backend.core.Features.Queries.EventQueries;
using snedson_ecology_backend.core.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Actions.EventActions
{
    public class GetEventByIdAction : AbstractAction
    {
        public GetEventByIdAction(IMediator mediator) : base(mediator)
        { }

        public async Task<GetEventRm> Action(Guid id)
        {
            return new GetEventRm
            {
                Event = await _mediator.Send(new GetEventByIdQuery { Id = id })
            };
        }
    }
}

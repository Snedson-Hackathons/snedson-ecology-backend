using MediatR;
using snedson_ecology_backend.core.Features.Queries.EventQueries;
using snedson_ecology_backend.core.Models.ResponseModels;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Actions.EventActions
{
    public class GetEventsAction : AbstractAction
    {
        public GetEventsAction(IMediator mediator) : base(mediator)
        { }

        public async Task<GetEventsRm> Action(int limit, int offset)
        {
            return new GetEventsRm
            {
                Events = await _mediator.Send(new GetEventsWithPaginationQuery { Limit = limit, Offset = offset })
            };
        }
    }
}

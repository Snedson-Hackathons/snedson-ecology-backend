using MediatR;

namespace snedson_ecology_backend.core.Actions
{
    public class AbstractAction
    {
        protected readonly IMediator _mediator;
        public AbstractAction(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

using MediatR;
using snedson_ecology_backend.core.Interfaces;

namespace snedson_ecology_backend.core.Features
{
    internal abstract class AbstractFeatureHandler
    {
        protected readonly IEcologyContext db;
        public AbstractFeatureHandler(IEcologyContext context)
        {
            db = context;
        }
    }

    internal abstract class AbstractFeatureHandlerWithMediatr : AbstractFeatureHandler
    {
        protected readonly IMediator _mediator;

        public AbstractFeatureHandlerWithMediatr
            (IEcologyContext context, IMediator mediator) : base(context)
        {
            _mediator = mediator;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using snedson_ecology_backend.core.Interfaces;
using snedson_ecology_backend.core.Models.Dtos;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Features.Queries.EventQueries
{
    internal class GetEventByIdQuery : IRequest<EventDto>
    {
        public Guid Id { get; set; }
    }

    internal class GetEventByIdQueryHandler
        : AbstractFeatureHandler, IRequestHandler<GetEventByIdQuery, EventDto>
    {
        public GetEventByIdQueryHandler(IEcologyContext context) : base(context)
        { }

        public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await db.Events
                .Where(e => e.Id == request.Id)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    ActualResult = e.ActualResult,
                    Author = e.Author,
                    Description = e.Description,
                    ExpectedResult = e.ExpectedResult,
                    LocationLat = e.LocationLat,
                    LocationLon = e.LocationLon,
                    ScheduledDate = e.ScheduledDate.Value,
                    Title = e.Title,
                    Needs = e.EventNeeds.Select(en => new EventNeedDto
                    {
                        Id = en.Need.Id,
                        Title = en.Need.Title,
                        IsChecked = en.Need.IsChecked
                    }).ToArray()
                })
                .SingleAsync();
        }
    }
}

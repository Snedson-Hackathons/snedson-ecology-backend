﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using snedson_ecology_backend.core.Interfaces;
using snedson_ecology_backend.core.Models.Dtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Features.Queries.EventQueries
{
    internal class GetEventsWithPaginationQuery : IRequest<EventDto[]>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    internal class GetEventsWithPaginationQueryHandler
        : AbstractFeatureHandler, IRequestHandler<GetEventsWithPaginationQuery, EventDto[]>
    {
        public GetEventsWithPaginationQueryHandler(IEcologyContext context) : base(context)
        { }

        public async Task<EventDto[]> Handle(GetEventsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = db.Events
                .Skip(request.Offset);

            if(request.Limit != 0)
            {
                query.Take(request.Limit);
            }

            return await query
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    ActualResult = e.ActualResult,
                    Author = e.Author,
                    Description = e.Description,
                    ParticipantsCount = e.EventParticipants.Count(),
                    ScheduledDate = e.ScheduledDate.Value,
                    Title = e.Title
                })
                .ToArrayAsync();
        }
    }
}

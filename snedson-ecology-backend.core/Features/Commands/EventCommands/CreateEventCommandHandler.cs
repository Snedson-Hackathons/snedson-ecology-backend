using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using snedson_ecology_backend.core.Interfaces;
using snedson_ecology_backend.core.Models.DbModels;
using snedson_ecology_backend.core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Features.Commands.EventCommands
{
    internal class CreateEventCommand : IRequest<Guid>
    {
        public EventDto EventModel { get; set; }
        public Guid AuthorId { get; set; }
    }

    internal class CreateEventCommandHandler
        : AbstractFeatureHandler, IRequestHandler<CreateEventCommand, Guid>
    {
        public CreateEventCommandHandler(IEcologyContext context) : base(context)
        { }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createdNeeds = CreateNeeds(request);

            var createdEvent = db.Add(new Event
            {
                Id = Guid.NewGuid(),
                Title = request.EventModel.Title,
                Description = request.EventModel.Description,
                Author = request.AuthorId,
                LocationLat = request.EventModel.LocationLat,
                LocationLon = request.EventModel.LocationLon,
                ScheduledDate = request.EventModel.ScheduledDate,
                ExpectedResult = request.EventModel.ExpectedResult,
                ActualResult = null,
            });

            await db.SaveChangesAsync();

            foreach(var need in createdNeeds)
            {
                db.Add(new EventNeed
                {
                    EventId = createdEvent.Entity.Id,
                    NeedId = need.Entity.Id
                });
            }

            await db.SaveChangesAsync();
            return createdEvent.Entity.Id;
        }

        private List<EntityEntry<Need>> CreateNeeds(CreateEventCommand request)
        {
            var createdNeeds = new List<EntityEntry<Need>>();

            foreach (var need in request.EventModel.Needs)
            {
                createdNeeds.Add(db.Add(new Need
                {
                    Title = need.Title,
                    IsChecked = false,
                }));
            }

            return createdNeeds;
        }
    }
}

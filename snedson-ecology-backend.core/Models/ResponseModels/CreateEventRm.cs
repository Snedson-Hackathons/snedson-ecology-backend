using System;

namespace snedson_ecology_backend.core.Models.ResponseModels
{
    public record CreateEventRm
    {
        public Guid CreatedEventId { get; set; }
    }
}

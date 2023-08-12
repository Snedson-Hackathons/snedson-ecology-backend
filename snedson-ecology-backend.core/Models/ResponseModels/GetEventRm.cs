using snedson_ecology_backend.core.Models.Dtos;

namespace snedson_ecology_backend.core.Models.ResponseModels
{
    public record GetEventRm
    {
        public EventDto Event { get; set; }
    }
}

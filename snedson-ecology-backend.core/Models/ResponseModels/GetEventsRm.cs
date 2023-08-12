using snedson_ecology_backend.core.Models.Dtos;

namespace snedson_ecology_backend.core.Models.ResponseModels
{
    public record GetEventsRm
    {
        public EventDto[] Events { get; set; }
    }
}

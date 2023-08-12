using System;

namespace snedson_ecology_backend.core.Models.Dtos
{
    public record EventDto
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public Guid? Author { get; set; }
        public string AuthorFullName { get; set; } = "Варламов Иван Анатольевич";
        public string Description { get; set; }
        public long ScheduledDate { get; set; }
        public string LocationLat { get; set; }
        public string LocationLon { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public EventNeedDto[] Needs { get; set; }
    }
}

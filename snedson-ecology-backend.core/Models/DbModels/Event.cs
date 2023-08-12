using System;
using System.Collections.Generic;

#nullable disable

namespace snedson_ecology_backend.core.Models.DbModels
{
    public partial class Event
    {
        public Event()
        {
            EventNeeds = new HashSet<EventNeed>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid Author { get; set; }
        public string Description { get; set; }
        public string LocationLat { get; set; }
        public string LocationLon { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public long? ScheduledDate { get; set; }

        public virtual Account AuthorNavigation { get; set; }
        public virtual ICollection<EventNeed> EventNeeds { get; set; }
    }
}

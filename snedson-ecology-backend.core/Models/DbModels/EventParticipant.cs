using snedson_ecology_backend.core.Models.DbModels;
using System;
using System.Collections.Generic;

#nullable disable

namespace snedson_ecology_backend.core.Models.DbModels
{
    public partial class EventParticipant
    {
        public Guid EventId { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Event Event { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace snedson_ecology_backend.core.Models.DbModels
{
    public partial class EventNeed
    {
        public Guid EventId { get; set; }
        public int NeedId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Need Need { get; set; }
    }
}

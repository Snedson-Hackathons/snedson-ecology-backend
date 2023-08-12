using System;
using System.Collections.Generic;

#nullable disable

namespace snedson_ecology_backend.core.Models.DbModels
{
    public partial class Need
    {
        public Need()
        {
            EventNeeds = new HashSet<EventNeed>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }

        public virtual ICollection<EventNeed> EventNeeds { get; set; }
    }
}

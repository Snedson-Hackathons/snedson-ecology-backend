using System;
using System.Collections.Generic;

#nullable disable

namespace snedson_ecology_backend.core.Models.DbModels
{
    public partial class Account
    {
        public Account()
        {
            Events = new HashSet<Event>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

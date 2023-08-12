using Microsoft.EntityFrameworkCore;
using snedson_ecology_backend.core.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Interfaces
{
    public interface IEcologyContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Account> Accounts { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventNeed> EventNeeds { get; set; }
        DbSet<Need> Needs { get; set; }
    }
}

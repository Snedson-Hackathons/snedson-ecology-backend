using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using snedson_ecology_backend.core.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snedson_ecology_backend.core.Interfaces
{
    public interface IEcologyContext
    {
        EntityEntry<TEntity> Add<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<Account> Accounts { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventNeed> EventNeeds { get; set; }
        DbSet<Need> Needs { get; set; }
    }
}

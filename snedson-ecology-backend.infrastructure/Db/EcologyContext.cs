using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using snedson_ecology_backend.core.Interfaces;
using snedson_ecology_backend.core.Models.DbModels;

#nullable disable

namespace snedson_ecology_backend.infrastructure.Db
{
    public partial class EcologyContext : DbContext, IEcologyContext
    {
        public EcologyContext()
        {
        }

        public EcologyContext(DbContextOptions<EcologyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventNeed> EventNeeds { get; set; }
        public virtual DbSet<Need> Needs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ActualResult).HasColumnName("actual_result");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExpectedResult).HasColumnName("expected_result");

                entity.Property(e => e.LocationLat).HasColumnName("location_lat");

                entity.Property(e => e.LocationLon).HasColumnName("location_lon");

                entity.Property(e => e.ScheduledDate)
                    .HasColumnType("time without time zone")
                    .HasColumnName("scheduled_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Author_fkey");
            });

            modelBuilder.Entity<EventNeed>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.NeedId })
                    .HasName("EventNeeds_pkey");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.NeedId).HasColumnName("need_id");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventNeeds)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EventNeeds_Event_fkey");

                entity.HasOne(d => d.Need)
                    .WithMany(p => p.EventNeeds)
                    .HasForeignKey(d => d.NeedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EventNeeds_Need_fkey");
            });

            modelBuilder.Entity<Need>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IsChecked).HasColumnName("is_checked");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

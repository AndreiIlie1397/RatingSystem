using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class RatingDbContext : DbContext
    {

        public RatingDbContext(DbContextOptions<RatingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConferenceXAttendeeRating> ConferenceXAttendees { get; set; }
        public virtual DbSet<ConferenceRating> ConferenceRating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ConferenceXAttendeeRating>(entity =>
            {
                entity.HasKey(c => new { c.Id });

                entity.ToTable("ConferenceXAttendeeRating");

                entity.Property(e => e.AttendeeEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
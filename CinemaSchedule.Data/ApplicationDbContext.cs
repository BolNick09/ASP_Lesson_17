using CinemaSchedule.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Конфигурация для Movie
            builder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Title).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Director).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Genre).IsRequired().HasMaxLength(50);
                entity.Property(m => m.Description).HasMaxLength(500);

                // Связь один-ко-многим с Session
                entity.HasMany(m => m.Sessions)
                      .WithOne()
                      .HasForeignKey(s => s.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Конфигурация для Session
            builder.Entity<Session>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.ShowTime).IsRequired();

                // Если MovieId не является nullable, добавляем обязательную связь
                entity.Property(s => s.MovieId).IsRequired();
            });
        }
    }
}

using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                        .HasKey(k => new { k.MovieId, k.GenreId });

            modelBuilder.Entity<MovieShowTime>()
                        .HasKey(k => new { k.MovieId, k.ShowTimeId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }

    }
}
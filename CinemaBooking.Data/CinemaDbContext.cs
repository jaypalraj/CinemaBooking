using CinemaBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<SeatBooking>()
                        .HasKey(k => new { k.SeatId, k.BookingId });

            #region GENRES

            modelBuilder.Entity<Genre>().HasData(
                    new Genre() { GenreId = 1, Title = "Action" }
                    , new Genre() { GenreId = 2, Title = "Horror" }
                    , new Genre() { GenreId = 3, Title = "Crime" }
                    , new Genre() { GenreId = 4, Title = "Drama" }
                    , new Genre() { GenreId = 5, Title = "Comedy" }
                    , new Genre() { GenreId = 6, Title = "Adventure" }
                    , new Genre() { GenreId = 7, Title = "Fantacy" }
                    , new Genre() { GenreId = 8, Title = "Romance" }
                    , new Genre() { GenreId = 9, Title = "Sci-Fi" }
                    , new Genre() { GenreId = 10, Title = "Mystrey" }
                );

            #endregion GENRES

            #region MOVIES

            modelBuilder.Entity<Movie>().HasData(
                    new Movie() { MovieId = 1, Title = "The Dark Knight", Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Ratings = 9m, TrailerUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY", IsActive = true }
                    , new Movie() { MovieId = 2, Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", Ratings = 8.8m, TrailerUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0", IsActive = true }
                    , new Movie() { MovieId = 3, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Ratings = 9.3m, TrailerUrl = "https://www.youtube.com/watch?v=6hB3S9bIaco", IsActive = true }
                    , new Movie() { MovieId = 4, Title = "The Prestige", Description = "After a tragic accident, two stage magicians engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", Ratings = 8.5m, TrailerUrl = "https://www.youtube.com/watch?v=ijXruSzfGEc", IsActive = true }
                    , new Movie() { MovieId = 5, Title = "Get Smart", Description = "Maxwell Smart, a highly intellectual but bumbling spy working for the CONTROL agency, is tasked with preventing a terrorist attack from rival spy agency KAOS.", Ratings = 6.5m, TrailerUrl = "https://www.youtube.com/watch?v=xbf9AWiJDBI", IsActive = true }
                    , new Movie() { MovieId = 6, Title = "Love & Other Drugs", Description = "A young woman suffering from Parkinson's befriends a drug rep working for Pfizer in 1990s Pittsburgh.", Ratings = 6.7m, TrailerUrl = "https://www.youtube.com/watch?v=h6w7Dh-QxzY", IsActive = true }
                    , new Movie() { MovieId = 7, Title = "American Pie", Description = "Four teenage boys enter a pact to lose their virginity by prom night.", Ratings = 7m, TrailerUrl = "https://www.youtube.com/watch?v=iUZ3Yxok6N8", IsActive = true }
                    , new Movie() { MovieId = 8, Title = "The Ruins", Description = "A group of friends whose leisurely Mexican holiday takes a turn for the worse when they, along with a fellow tourist, embark on a remote archaeological dig in the jungle where something evil lives among the ruins.", Ratings = 5.9m, TrailerUrl = "https://www.youtube.com/watch?v=xVlBRkigRvc", IsActive = true }
                    );

            #endregion MOVIES

            #region MOVIE GENRES

            modelBuilder.Entity<MovieGenre>().HasData(
                    new MovieGenre() { MovieId = 1, GenreId = 1 }
                    , new MovieGenre() { MovieId = 1, GenreId = 3 }
                    , new MovieGenre() { MovieId = 1, GenreId = 4 }
                    , new MovieGenre() { MovieId = 2, GenreId = 1 }
                    , new MovieGenre() { MovieId = 2, GenreId = 6 }
                    , new MovieGenre() { MovieId = 2, GenreId = 9 }
                    , new MovieGenre() { MovieId = 3, GenreId = 4 }
                    , new MovieGenre() { MovieId = 4, GenreId = 4 }
                    , new MovieGenre() { MovieId = 4, GenreId = 9 }
                    , new MovieGenre() { MovieId = 4, GenreId = 10 }
                    , new MovieGenre() { MovieId = 5, GenreId = 1 }
                    , new MovieGenre() { MovieId = 5, GenreId = 6 }
                    , new MovieGenre() { MovieId = 5, GenreId = 5 }
                    , new MovieGenre() { MovieId = 6, GenreId = 5 }
                    , new MovieGenre() { MovieId = 6, GenreId = 4 }
                    , new MovieGenre() { MovieId = 6, GenreId = 8 }
                    , new MovieGenre() { MovieId = 7, GenreId = 5 }
                    , new MovieGenre() { MovieId = 8, GenreId = 2 }
                );

            #endregion MOVIE GENRES

            #region SCREENS

            modelBuilder.Entity<Screen>().HasData(
                    new Screen() { ScreenId = 1, Title = "Screen1" }
                    , new Screen() { ScreenId = 2, Title = "Screen2" }
                    , new Screen() { ScreenId = 3, Title = "Screen3" }
                    , new Screen() { ScreenId = 4, Title = "Screen4" }
                    , new Screen() { ScreenId = 5, Title = "Screen5" }
                );

            #endregion SCREENS

            #region SHOW TIMES

            modelBuilder.Entity<ShowTime>().HasData(
                    new ShowTime() { ShowTimeId = 1, ShowDateTime = new DateTime(2019, 05, 27, 14, 15, 00), ScreenId = 1 }
                    , new ShowTime() { ShowTimeId = 2, ShowDateTime = new DateTime(2019, 05, 27, 17, 45, 00), ScreenId = 1 }
                    , new ShowTime() { ShowTimeId = 3, ShowDateTime = new DateTime(2019, 05, 27, 20, 15, 00), ScreenId = 1 }

                    , new ShowTime() { ShowTimeId = 4, ShowDateTime = new DateTime(2019, 05, 27, 15, 00, 00), ScreenId = 2 }
                    , new ShowTime() { ShowTimeId = 5, ShowDateTime = new DateTime(2019, 05, 27, 18, 00, 00), ScreenId = 2 }
                    , new ShowTime() { ShowTimeId = 6, ShowDateTime = new DateTime(2019, 05, 27, 21, 00, 00), ScreenId = 2 }
                    , new ShowTime() { ShowTimeId = 7, ShowDateTime = new DateTime(2019, 05, 27, 23, 00, 00), ScreenId = 2 }

                    , new ShowTime() { ShowTimeId = 8, ShowDateTime = new DateTime(2019, 05, 27, 13, 45, 00), ScreenId = 3 }
                    , new ShowTime() { ShowTimeId = 9, ShowDateTime = new DateTime(2019, 05, 27, 15, 45, 00), ScreenId = 3 }
                    , new ShowTime() { ShowTimeId = 10, ShowDateTime = new DateTime(2019, 05, 27, 22, 00, 00), ScreenId = 3 }

                    , new ShowTime() { ShowTimeId = 11, ShowDateTime = new DateTime(2019, 05, 27, 15, 15, 00), ScreenId = 4 }
                    , new ShowTime() { ShowTimeId = 12, ShowDateTime = new DateTime(2019, 05, 27, 19, 15, 00), ScreenId = 4 }
                    , new ShowTime() { ShowTimeId = 13, ShowDateTime = new DateTime(2019, 05, 27, 22, 15, 00), ScreenId = 4 }

                    , new ShowTime() { ShowTimeId = 14, ShowDateTime = new DateTime(2019, 05, 27, 14, 45, 00), ScreenId = 5 }
                    , new ShowTime() { ShowTimeId = 15, ShowDateTime = new DateTime(2019, 05, 27, 18, 15, 00), ScreenId = 5 }
                    , new ShowTime() { ShowTimeId = 16, ShowDateTime = new DateTime(2019, 05, 27, 21, 00, 00), ScreenId = 5 }
                );

            #endregion SHOW TIMES

            #region MOVIE SHOW TIME

            modelBuilder.Entity<MovieShowTime>().HasData(
                    new MovieShowTime() { MovieId = 1, ShowTimeId = 3 }
                    , new MovieShowTime() { MovieId = 1, ShowTimeId = 6 }
                    , new MovieShowTime() { MovieId = 1, ShowTimeId = 7 }
                    , new MovieShowTime() { MovieId = 1, ShowTimeId = 10 }
                    , new MovieShowTime() { MovieId = 1, ShowTimeId = 13 }
                    , new MovieShowTime() { MovieId = 1, ShowTimeId = 15 }

                    , new MovieShowTime() { MovieId = 2, ShowTimeId = 2 }
                    , new MovieShowTime() { MovieId = 2, ShowTimeId = 5 }
                    , new MovieShowTime() { MovieId = 2, ShowTimeId = 8 }
                );

            #endregion MOVIE SHOW TIME

            #region SEATS

            modelBuilder.Entity<Seat>().HasData(

                    new Seat() { SeatId = 1, Title = "A1", ScreenId = 1 }
                    , new Seat() { SeatId = 2, Title = "A2", ScreenId = 1 }
                    , new Seat() { SeatId = 3, Title = "A3", ScreenId = 1 }
                    , new Seat() { SeatId = 4, Title = "A4", ScreenId = 1 }
                    , new Seat() { SeatId = 5, Title = "A5", ScreenId = 1 }
                    , new Seat() { SeatId = 6, Title = "A6", ScreenId = 1 }
                    , new Seat() { SeatId = 7, Title = "A7", ScreenId = 1 }
                    , new Seat() { SeatId = 8, Title = "A8", ScreenId = 1 }
                    , new Seat() { SeatId = 9, Title = "A9", ScreenId = 1 }
                    , new Seat() { SeatId = 10, Title = "A10", ScreenId = 1 }

                    , new Seat() { SeatId = 11, Title = "B1", ScreenId = 1 }
                    , new Seat() { SeatId = 12, Title = "B2", ScreenId = 1 }
                    , new Seat() { SeatId = 13, Title = "B3", ScreenId = 1 }
                    , new Seat() { SeatId = 14, Title = "B4", ScreenId = 1 }
                    , new Seat() { SeatId = 15, Title = "B5", ScreenId = 1 }
                    , new Seat() { SeatId = 16, Title = "B6", ScreenId = 1 }
                    , new Seat() { SeatId = 17, Title = "B7", ScreenId = 1 }
                    , new Seat() { SeatId = 18, Title = "B8", ScreenId = 1 }
                    , new Seat() { SeatId = 19, Title = "B9", ScreenId = 1 }
                    , new Seat() { SeatId = 20, Title = "B10", ScreenId = 1 }

                    , new Seat() { SeatId = 21, Title = "C1", ScreenId = 1 }
                    , new Seat() { SeatId = 22, Title = "C2", ScreenId = 1 }
                    , new Seat() { SeatId = 23, Title = "C3", ScreenId = 1 }
                    , new Seat() { SeatId = 24, Title = "C4", ScreenId = 1 }
                    , new Seat() { SeatId = 25, Title = "C5", ScreenId = 1 }
                    , new Seat() { SeatId = 26, Title = "C6", ScreenId = 1 }
                    , new Seat() { SeatId = 27, Title = "C7", ScreenId = 1 }
                    , new Seat() { SeatId = 28, Title = "C8", ScreenId = 1 }
                    , new Seat() { SeatId = 29, Title = "C9", ScreenId = 1 }
                    , new Seat() { SeatId = 30, Title = "C10", ScreenId = 1 }

                    , new Seat() { SeatId = 31, Title = "A1", ScreenId = 2 }
                    , new Seat() { SeatId = 32, Title = "A2", ScreenId = 2 }
                    , new Seat() { SeatId = 33, Title = "A3", ScreenId = 2 }
                    , new Seat() { SeatId = 34, Title = "A4", ScreenId = 2 }
                    , new Seat() { SeatId = 35, Title = "A5", ScreenId = 2 }
                    , new Seat() { SeatId = 36, Title = "A6", ScreenId = 2 }
                    , new Seat() { SeatId = 37, Title = "A7", ScreenId = 2 }
                    , new Seat() { SeatId = 38, Title = "A8", ScreenId = 2 }

                    , new Seat() { SeatId = 39, Title = "B1", ScreenId = 2 }
                    , new Seat() { SeatId = 40, Title = "B2", ScreenId = 2 }
                    , new Seat() { SeatId = 41, Title = "B3", ScreenId = 2 }
                    , new Seat() { SeatId = 42, Title = "B4", ScreenId = 2 }
                    , new Seat() { SeatId = 43, Title = "B5", ScreenId = 2 }
                    , new Seat() { SeatId = 44, Title = "B6", ScreenId = 2 }
                    , new Seat() { SeatId = 45, Title = "B7", ScreenId = 2 }
                    , new Seat() { SeatId = 46, Title = "B8", ScreenId = 2 }

                    , new Seat() { SeatId = 47, Title = "A1", ScreenId = 3 }
                    , new Seat() { SeatId = 48, Title = "A2", ScreenId = 3 }
                    , new Seat() { SeatId = 49, Title = "A3", ScreenId = 3 }
                    , new Seat() { SeatId = 50, Title = "A4", ScreenId = 3 }
                    , new Seat() { SeatId = 51, Title = "A5", ScreenId = 3 }
                    , new Seat() { SeatId = 52, Title = "A6", ScreenId = 3 }
                    , new Seat() { SeatId = 53, Title = "A7", ScreenId = 3 }
                    , new Seat() { SeatId = 54, Title = "A8", ScreenId = 3 }

                    , new Seat() { SeatId = 55, Title = "B1", ScreenId = 3 }
                    , new Seat() { SeatId = 56, Title = "B2", ScreenId = 3 }
                    , new Seat() { SeatId = 57, Title = "B3", ScreenId = 3 }
                    , new Seat() { SeatId = 58, Title = "B4", ScreenId = 3 }
                    , new Seat() { SeatId = 59, Title = "B5", ScreenId = 3 }
                    , new Seat() { SeatId = 60, Title = "B6", ScreenId = 3 }
                    , new Seat() { SeatId = 61, Title = "B7", ScreenId = 3 }
                    , new Seat() { SeatId = 62, Title = "B8", ScreenId = 3 }

                    , new Seat() { SeatId = 63, Title = "C1", ScreenId = 3 }
                    , new Seat() { SeatId = 64, Title = "C2", ScreenId = 3 }
                    , new Seat() { SeatId = 65, Title = "C3", ScreenId = 3 }
                    , new Seat() { SeatId = 66, Title = "C4", ScreenId = 3 }
                    , new Seat() { SeatId = 67, Title = "C5", ScreenId = 3 }
                    , new Seat() { SeatId = 68, Title = "C6", ScreenId = 3 }
                    , new Seat() { SeatId = 69, Title = "C7", ScreenId = 3 }
                    , new Seat() { SeatId = 70, Title = "C8", ScreenId = 3 }

                    , new Seat() { SeatId = 71, Title = "A1", ScreenId = 4 }
                    , new Seat() { SeatId = 72, Title = "A2", ScreenId = 4 }
                    , new Seat() { SeatId = 73, Title = "A3", ScreenId = 4 }
                    , new Seat() { SeatId = 74, Title = "A4", ScreenId = 4 }
                    , new Seat() { SeatId = 75, Title = "A5", ScreenId = 4 }
                    , new Seat() { SeatId = 76, Title = "A6", ScreenId = 4 }
                    , new Seat() { SeatId = 77, Title = "A7", ScreenId = 4 }
                    , new Seat() { SeatId = 78, Title = "A8", ScreenId = 4 }
                    , new Seat() { SeatId = 79, Title = "A9", ScreenId = 4 }
                    , new Seat() { SeatId = 80, Title = "A10", ScreenId = 4 }

                    , new Seat() { SeatId = 81, Title = "B1", ScreenId = 4 }
                    , new Seat() { SeatId = 82, Title = "B2", ScreenId = 4 }
                    , new Seat() { SeatId = 83, Title = "B3", ScreenId = 4 }
                    , new Seat() { SeatId = 84, Title = "B4", ScreenId = 4 }
                    , new Seat() { SeatId = 85, Title = "B5", ScreenId = 4 }
                    , new Seat() { SeatId = 86, Title = "B6", ScreenId = 4 }
                    , new Seat() { SeatId = 87, Title = "B7", ScreenId = 4 }
                    , new Seat() { SeatId = 88, Title = "B8", ScreenId = 4 }
                    , new Seat() { SeatId = 89, Title = "B9", ScreenId = 4 }
                    , new Seat() { SeatId = 90, Title = "B10", ScreenId = 4 }

                    , new Seat() { SeatId = 91, Title = "C1", ScreenId = 4 }
                    , new Seat() { SeatId = 92, Title = "C2", ScreenId = 4 }
                    , new Seat() { SeatId = 93, Title = "C3", ScreenId = 4 }
                    , new Seat() { SeatId = 94, Title = "C4", ScreenId = 4 }
                    , new Seat() { SeatId = 95, Title = "C5", ScreenId = 4 }
                    , new Seat() { SeatId = 96, Title = "C6", ScreenId = 4 }
                    , new Seat() { SeatId = 97, Title = "C7", ScreenId = 4 }
                    , new Seat() { SeatId = 98, Title = "C8", ScreenId = 4 }
                    , new Seat() { SeatId = 99, Title = "C9", ScreenId = 4 }
                    , new Seat() { SeatId = 100, Title = "C10", ScreenId = 4 }

                    , new Seat() { SeatId = 101, Title = "D1", ScreenId = 4 }
                    , new Seat() { SeatId = 102, Title = "D2", ScreenId = 4 }
                    , new Seat() { SeatId = 103, Title = "D3", ScreenId = 4 }
                    , new Seat() { SeatId = 104, Title = "D4", ScreenId = 4 }
                    , new Seat() { SeatId = 105, Title = "D5", ScreenId = 4 }
                    , new Seat() { SeatId = 106, Title = "D6", ScreenId = 4 }
                    , new Seat() { SeatId = 107, Title = "D7", ScreenId = 4 }
                    , new Seat() { SeatId = 108, Title = "D8", ScreenId = 4 }
                    , new Seat() { SeatId = 109, Title = "D9", ScreenId = 4 }
                    , new Seat() { SeatId = 110, Title = "D10", ScreenId = 4 }

                    , new Seat() { SeatId = 111, Title = "E1", ScreenId = 4 }
                    , new Seat() { SeatId = 112, Title = "E2", ScreenId = 4 }
                    , new Seat() { SeatId = 113, Title = "E3", ScreenId = 4 }
                    , new Seat() { SeatId = 114, Title = "E4", ScreenId = 4 }
                    , new Seat() { SeatId = 115, Title = "E5", ScreenId = 4 }
                    , new Seat() { SeatId = 116, Title = "E6", ScreenId = 4 }
                    , new Seat() { SeatId = 117, Title = "E7", ScreenId = 4 }
                    , new Seat() { SeatId = 118, Title = "E8", ScreenId = 4 }
                    , new Seat() { SeatId = 119, Title = "E9", ScreenId = 4 }
                    , new Seat() { SeatId = 120, Title = "E10", ScreenId = 4 }

                    , new Seat() { SeatId = 121, Title = "B1", ScreenId = 5 }
                    , new Seat() { SeatId = 122, Title = "B2", ScreenId = 5 }
                    , new Seat() { SeatId = 123, Title = "B3", ScreenId = 5 }
                    , new Seat() { SeatId = 124, Title = "B4", ScreenId = 5 }
                    , new Seat() { SeatId = 125, Title = "B5", ScreenId = 5 }
                    , new Seat() { SeatId = 126, Title = "B6", ScreenId = 5 }
                    , new Seat() { SeatId = 127, Title = "B7", ScreenId = 5 }
                    , new Seat() { SeatId = 128, Title = "B8", ScreenId = 5 }
                    , new Seat() { SeatId = 129, Title = "B9", ScreenId = 5 }
                    , new Seat() { SeatId = 130, Title = "B10", ScreenId = 5 }

                    , new Seat() { SeatId = 131, Title = "C1", ScreenId = 5 }
                    , new Seat() { SeatId = 132, Title = "C2", ScreenId = 5 }
                    , new Seat() { SeatId = 133, Title = "C3", ScreenId = 5 }
                    , new Seat() { SeatId = 134, Title = "C4", ScreenId = 5 }
                    , new Seat() { SeatId = 135, Title = "C5", ScreenId = 5 }
                    , new Seat() { SeatId = 136, Title = "C6", ScreenId = 5 }
                    , new Seat() { SeatId = 137, Title = "C7", ScreenId = 5 }
                    , new Seat() { SeatId = 138, Title = "C8", ScreenId = 5 }
                    , new Seat() { SeatId = 139, Title = "C9", ScreenId = 5 }
                    , new Seat() { SeatId = 140, Title = "C10", ScreenId = 5 }

                    , new Seat() { SeatId = 141, Title = "D1", ScreenId = 5 }
                    , new Seat() { SeatId = 142, Title = "D2", ScreenId = 5 }
                    , new Seat() { SeatId = 143, Title = "D3", ScreenId = 5 }
                    , new Seat() { SeatId = 144, Title = "D4", ScreenId = 5 }
                    , new Seat() { SeatId = 145, Title = "D5", ScreenId = 5 }
                    , new Seat() { SeatId = 146, Title = "D6", ScreenId = 5 }
                    , new Seat() { SeatId = 147, Title = "D7", ScreenId = 5 }
                    , new Seat() { SeatId = 148, Title = "D8", ScreenId = 5 }
                    , new Seat() { SeatId = 149, Title = "D9", ScreenId = 5 }
                    , new Seat() { SeatId = 150, Title = "D10", ScreenId = 5 }

                    , new Seat() { SeatId = 151, Title = "E1", ScreenId = 5 }
                    , new Seat() { SeatId = 152, Title = "E2", ScreenId = 5 }
                    , new Seat() { SeatId = 153, Title = "E3", ScreenId = 5 }
                    , new Seat() { SeatId = 154, Title = "E4", ScreenId = 5 }
                    , new Seat() { SeatId = 155, Title = "E5", ScreenId = 5 }
                    , new Seat() { SeatId = 156, Title = "E6", ScreenId = 5 }
                    , new Seat() { SeatId = 157, Title = "E7", ScreenId = 5 }
                    , new Seat() { SeatId = 158, Title = "E8", ScreenId = 5 }
                    , new Seat() { SeatId = 159, Title = "E9", ScreenId = 5 }
                    , new Seat() { SeatId = 160, Title = "E10", ScreenId = 5 }

                    );

            #endregion SEATS

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
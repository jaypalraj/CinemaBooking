using CinemaBooking.Data;
using CinemaBooking.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CinemaBooking.Tests.RepositoryTests
{
    public class BookingRepositoryShould
    {
        private DbContextOptions<CinemaDbContext> _options;
        private CinemaDbContext _dbContext;
        private FakeData _fake;

        public BookingRepositoryShould()
        {
            _options = new DbContextOptionsBuilder<CinemaDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _dbContext = new CinemaDbContext(_options);
            _fake = new FakeData();

            _fake.SeedInMemoryData(_dbContext);
        }


        [Fact]
        public void GetBookingsForUser()
        {
            var booking = _dbContext.Bookings.Single(b => b.User.Email == "jaypalraj@example.com");
            Assert.NotNull(booking.Seats);
            Assert.Equal(3, booking.Seats.Count());
        }

        [Fact]
        public void GetAvailabelSeatsForMovie()
        {
            var movie = _dbContext.Movies.Single(m => m.Title == "Batman Begins");
            var showTime = movie.MovieShowTimes.Single(mt => mt.ShowTime.ShowDateTime.Day == 21
                                                      && mt.ShowTime.ShowDateTime.Month == 5
                                                      && mt.ShowTime.ShowDateTime.Year == 2019
                                                      && mt.ShowTime.ShowDateTime.Hour == 14);

            var screen = _dbContext.Screens.Single(s => s.ShowTimes.Any(st => st.ShowTimeId == showTime.ShowTimeId));

            var bookedSeats = screen.Seats.Where(s => s.Booking != null);

            Assert.NotNull(screen.Seats);

            Assert.Equal(5, screen.Seats.Count() - bookedSeats.Count());
        }
    }
}

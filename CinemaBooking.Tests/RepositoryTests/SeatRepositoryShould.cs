using CinemaBooking.Data;
using CinemaBooking.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CinemaBooking.Tests.RepositoryTests
{
    public class SeatRepositoryShould
    {
        private DbContextOptions<CinemaDbContext> _options;
        private CinemaDbContext _dbContext;
        private FakeData _fake;

        public SeatRepositoryShould()
        {
            _options = new DbContextOptionsBuilder<CinemaDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _dbContext = new CinemaDbContext(_options);
            _fake = new FakeData();

            _fake.SeedInMemoryData(_dbContext);
        }

        [Fact]
        public void GetSeatsForScreen()
        {
            var screen1 = "Screen1";

            var seats = _dbContext.Seats.Where(s => s.Screen.Title == screen1);

            Assert.True(seats.Count() == 10);
        }
    }
}
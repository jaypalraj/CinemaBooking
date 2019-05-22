using CinemaBooking.Data;
using CinemaBooking.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CinemaBooking.Tests.RepositoryTests
{
    public class ShowTimeRepositoryShould
    {
        private DbContextOptions<CinemaDbContext> _options;
        private CinemaDbContext _dbContext;
        private FakeData _fake;

        public ShowTimeRepositoryShould()
        {
            _options = new DbContextOptionsBuilder<CinemaDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _dbContext = new CinemaDbContext(_options);
            _fake = new FakeData();

            _fake.SeedInMemoryData(_dbContext);

        }


        [Fact]
        public void GetAllActiveShowTimes()
        {
            var showTimes = _dbContext.ShowTimes.Where(s => s.ShowDateTime > DateTime.Now.AddDays(-1));
            Assert.NotNull(showTimes);
        }

        [Theory]
        [InlineData("Batman Begins")]
        [InlineData("Evil Dead")]
        public void GetShowTimesForMovie(string movieTitle)
        {
            var showTimes = _dbContext.ShowTimes.Where(s => s.ShowDateTime > DateTime.Now.AddDays(-1)
                                                         && s.MovieShowTimes.Any(m => m.Movie.Title == movieTitle));
            Assert.NotNull(showTimes);
        }
        


    }
}
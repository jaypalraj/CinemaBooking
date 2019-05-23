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
        private DateTime _refDateTime = new DateTime(2019,05,20);

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
            var showTimes = _dbContext.ShowTimes.Where(s => s.ShowDateTime > _refDateTime);
            Assert.NotNull(showTimes);
        }

        [Theory]
        [InlineData("Batman Begins")]
        [InlineData("Evil Dead")]
        //[InlineData("Notebook")]
        public void GetShowTimesForMoviesWithAllotatedScreen(string movieTitle)
        {
            var movieShowTimes = _dbContext.ShowTimes.Where(s => s.MovieShowTimes.Any(m => m.Movie.Title == movieTitle));
            var screens = movieShowTimes.Any(ms => ms.Screen != null);
            Assert.NotNull(movieShowTimes);
            Assert.True(screens);
            
        }
        


    }
}
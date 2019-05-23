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
    public class ScreenRepositoryShould
    {
        private DbContextOptions<CinemaDbContext> _options;
        private CinemaDbContext _dbContext;
        private FakeData _fake;

        public ScreenRepositoryShould()
        {
            _options = new DbContextOptionsBuilder<CinemaDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _dbContext = new CinemaDbContext(_options);
            _fake = new FakeData();

            _fake.SeedInMemoryData(_dbContext);
        }


        [Theory]
        [InlineData("Batman Begins")]
        [InlineData("Evil Dead")]
        //[InlineData("Notebook")]
        public void GetAllScreensForMovie(string movieTitle)
        {
            var movieScreens = _dbContext.Screens.Where(s => s.ShowTimes.Any(st => st.MovieShowTimes.Any(m => m.Movie.Title == movieTitle)));
            Assert.True(movieScreens.Any());
        }

        [Fact]
        public void GetScreenForMovieAtDateTime()
        {
            var movieTitle = "Batman Begins";
            var dateTime = new DateTime(2019,05,22,14,00,00);

            var movieScreen = _dbContext.Screens.Where(s => s.ShowTimes.Any(st => st.ShowDateTime == dateTime && st.MovieShowTimes.Any(m => m.Movie.Title == movieTitle)));
            Assert.Single(movieScreen);
        }
    }
}

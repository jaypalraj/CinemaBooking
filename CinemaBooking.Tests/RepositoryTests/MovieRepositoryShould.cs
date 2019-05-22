using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Tests.Core;
using CinemaBooking.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CinemaBooking.Tests.RepositoryTests
{
    public class MovieRepositoryShould
    {
        private DbContextOptions<CinemaDbContext> _options;
        private CinemaDbContext _dbContext;
        private FakeData _fake;
        private readonly ILogger<MovieRepositoryShould> _logger;

        public MovieRepositoryShould(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<MovieRepositoryShould>();

            _options = new DbContextOptionsBuilder<CinemaDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .EnableSensitiveDataLogging()
                            //.UseLoggerFactory(loggerFactory)
                            .Options;
            _dbContext = new CinemaDbContext(_options);
            _fake = new FakeData();
            _fake.SeedInMemoryData(_dbContext);
        }

        [Fact]
        public void InsertMovie()
        {
            var movie = new Movie
            {
                Title = "Seven"
            };

            var thrillerGenre = _dbContext.Genres.Single(g => g.Title == "Thriller");
            var horrorGenre = _dbContext.Genres.Single(g => g.Title == "Horror");

            movie.MovieGenres = new List<MovieGenre>()
            {
                new MovieGenre { Movie = movie, Genre = thrillerGenre },
                new MovieGenre { Movie = movie, Genre = horrorGenre }
            };

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            var movieAgain = _dbContext.Movies.Include(m => m.MovieGenres)
                                              .Single(m => m.MovieId == movie.MovieId);

            Assert.NotNull(movie.MovieGenres);
            Assert.Equal(2, movie.MovieGenres.Count());
        }

        [Fact]
        public void UpdateMovie()
        {
            var movie = _dbContext.Movies.Include(m => m.MovieGenres).Single(m => m.Title == "Inception");

            var genre = _dbContext.Genres.Single(g => g.Title == "Drama");

            movie.MovieGenres.Add(new MovieGenre
            {
                Movie = movie,
                Genre = genre
            });

            _dbContext.SaveChanges();

            var movieAgain = _dbContext.Movies.Include(m => m.MovieGenres)
                                              .Single(m => m.MovieId == movie.MovieId);

            Assert.NotNull(movieAgain.MovieGenres);
            Assert.Single(movieAgain.MovieGenres);
        }

        [Fact]
        public void GetMovies()
        {
            var movies = _dbContext.Movies;

            Assert.NotNull(movies);
            Assert.True(movies.Any());
        }

        [Fact]
        public void GetMoviesByGenre()
        {
            var dramas = _dbContext.Movies.Where(m => m.MovieGenres.Any(g => g.Genre.Title == "Drama"));
            Assert.Equal(2, dramas.Count());
        }
    }
}
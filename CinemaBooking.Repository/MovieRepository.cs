using System;
using System.Collections.Generic;
using System.Linq;
using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;

namespace CinemaBooking.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Movie> GetAllActiveMovies()
        {
            return db.Movies.Where(m => m.IsActive == true);
        }

        public Movie GetByMovieId(int movieId)
        {
            return db.Movies.Single(m => m.MovieId == movieId);
        }

        public IEnumerable<Movie> GetMoviesForGenre(int genreId)
        {
            return db.Movies.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
        }
    }
}
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBooking.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public Movie InsertMovie(Movie movie)
        {
            db.Movies.Add(movie);
            return movie;
        }

        public Movie UpdateMovie(Movie movie)
        {
            var entity = db.Movies.Attach(movie);
            entity.State = EntityState.Modified;
            return movie;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies;
        }

        public IEnumerable<Movie> GetMoviesForGenre(int genreId)
        {
            return db.Movies.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId));
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
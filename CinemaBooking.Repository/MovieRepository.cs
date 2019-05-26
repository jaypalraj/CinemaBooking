using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Movie>> GetAllActiveMoviesAsync()
        {
            var movies = db.Movies as IQueryable<Movie>;
            return await movies.Where(m => m.IsActive == true)?.ToListAsync();
        }

        public async Task<Movie> GetByMovieIdAsync(int movieId)
        {
            var movies = db.Movies
                           .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                           .Include(m => m.MovieShowTimes).ThenInclude(m => m.ShowTime)
                           as IQueryable<Movie>;
            return await movies.SingleAsync(m => m.MovieId == movieId);
        }

        public async Task<ICollection<Movie>> GetMoviesAtShowTime(int showTimeId)
        {
            var movies = db.Movies as IQueryable<Movie>;

            return await movies.Where(m => m.MovieShowTimes.Any(mst => mst.ShowTimeId == showTimeId)).ToListAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesForGenreAsync(int genreId)
        {
            var movies = db.Movies as IQueryable<Movie>;
            return await movies.Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))?.ToListAsync();
        }
    }
}
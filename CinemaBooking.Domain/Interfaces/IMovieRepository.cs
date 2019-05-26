using CinemaBooking.Domain.Entities;
using System.Collections.Generic;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllActiveMovies();

        Movie GetByMovieId(int movieId);

        IEnumerable<Movie> GetMoviesForGenre(int genreId);
    }
}
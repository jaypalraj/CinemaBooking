using CinemaBooking.Domain.Entities;
using System.Collections.Generic;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Movie InsertMovie(Movie movie);

        Movie UpdateMovie(Movie movie);

        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Movie> GetMoviesForGenre(int genreId);
    }
}
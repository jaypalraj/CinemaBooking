using CinemaBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllActiveMoviesAsync();

        Task<Movie> GetByMovieIdAsync(int movieId);

        Task<ICollection<Movie>> GetMoviesForGenreAsync(int genreId);

        Task<ICollection<Movie>> GetMoviesAtShowTime(int showTimeId);
    }
}
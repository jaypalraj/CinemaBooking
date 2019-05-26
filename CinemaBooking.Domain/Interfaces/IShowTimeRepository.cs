using CinemaBooking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IShowTimeRepository
    {
        Task<ICollection<ShowTime>> GetShowTimesForMovieAsync(int movieId);
    }
}
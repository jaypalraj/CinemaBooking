using CinemaBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IScreenRepository
    {
        Task<ICollection<Screen>> GetAllScreensForShowtimeAsync(int showTimeId);
        Task<Screen> GetScreenForMovieAtShowtimeAsync(int movieId, int showTimeId);
    }
}

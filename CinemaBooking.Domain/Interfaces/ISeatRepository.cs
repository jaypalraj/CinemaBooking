using CinemaBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<ICollection<Seat>> GetSeatsForScreen(int screenId);
        Task<ICollection<Seat>> GetBookedSeats(int movieId, int showTimeId);
    }
}

using System.Threading.Tasks;
using CinemaBooking.Domain.Entities;

namespace CinemaBooking.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> SaveBooking(Booking obj);
    }
}
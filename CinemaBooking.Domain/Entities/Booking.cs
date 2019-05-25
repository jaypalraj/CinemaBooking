using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
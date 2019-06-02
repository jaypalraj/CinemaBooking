using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public Seat Seat { get; set; }
        public int SeatId { get; set; }
    }
}
using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
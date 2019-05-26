using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string Title { get; set; }
        public Screen Screen { get; set; }
        public int ScreenId { get; set; }
        public List<SeatBooking> SeatBookings { get; set; }
    }
}
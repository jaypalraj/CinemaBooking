using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Screen
    {
        public int ScreenId { get; set; }
        public string Title { get; set; }
        public ShowTime ShowTime { get; set; }
        public int ShowTimeId { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Screen
    {
        public int ScreenId { get; set; }
        public string Title { get; set; }
        public List<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
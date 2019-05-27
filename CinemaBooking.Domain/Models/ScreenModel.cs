using System.Collections.Generic;

namespace CinemaBooking.Domain.Models
{
    public class ScreenModel
    {
        public int ScreenId { get; set; }
        public string Title { get; set; }
        public List<SeatModel> Seats { get; set; }
    }
}
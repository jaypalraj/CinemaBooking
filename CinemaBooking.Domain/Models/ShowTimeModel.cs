using System;

namespace CinemaBooking.Domain.Models
{
    public class ShowTimeModel
    {
        public int ShowTimeId { get; set; }
        public DateTime ShowDateTime { get; set; }
        public ScreenModel Screen { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class ShowTime
    {
        public int ShowTimeId { get; set; }
        public DateTime ShowDateTime { get; set; }

        public Screen Screen { get; set; }
        public int ScreenId { get; set; }

        public List<MovieShowTime> MovieShowTimes { get; set; }
    }
}
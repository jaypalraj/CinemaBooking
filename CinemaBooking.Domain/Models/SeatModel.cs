using System;

namespace CinemaBooking.Domain.Models
{
    public class SeatModel
    {
        public int SeatId { get; set; }
        public string Title { get; set; }

        public bool IsSelected { get; set; }
    }
}
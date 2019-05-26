using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Entities
{
    public class SeatBooking
    {
        public Seat Seat { get; set; }
        public int SeatId { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}

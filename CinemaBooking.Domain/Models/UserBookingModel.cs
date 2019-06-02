using CinemaBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Models
{
    public class UserBookingModel
    {
        public AppUser User { get; set; }
        public MovieModel Movie { get; set; }
        public ScreenModel Screen { get; set; }
    }
}

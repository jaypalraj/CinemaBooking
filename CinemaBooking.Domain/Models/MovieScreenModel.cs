using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Models
{
    public class MovieScreenModel
    {
        public MovieModel Movie { get; set; }
        public ScreenModel Screen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Models
{
    public class ScreenModel
    {
        public int ScreenId { get; set; }
        public string Title { get; set; }
        public List<SeatModel> Seats { get; set; }
    }
}

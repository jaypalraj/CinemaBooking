using CinemaBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Domain.Models
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Ratings { get; set; }
        public string TrailerUrl { get; set; }
        public List<string> Genres { get; set; }
        public List<ShowTimeModel> ShowDateTimes { get; set; }
    }
}

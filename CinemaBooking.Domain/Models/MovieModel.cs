using System.Collections.Generic;

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
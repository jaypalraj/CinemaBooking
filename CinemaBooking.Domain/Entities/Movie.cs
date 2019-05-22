using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<MovieShowTime> MovieShowTimes { get; set; }
    }
}
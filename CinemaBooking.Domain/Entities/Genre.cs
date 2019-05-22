using System.Collections.Generic;

namespace CinemaBooking.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
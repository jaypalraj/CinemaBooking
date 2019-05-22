namespace CinemaBooking.Domain.Entities
{
    public class MovieShowTime
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
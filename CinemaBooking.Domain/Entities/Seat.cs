namespace CinemaBooking.Domain.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string Title { get; set; }
        public Screen Screen { get; set; }
        public int ScreenId { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
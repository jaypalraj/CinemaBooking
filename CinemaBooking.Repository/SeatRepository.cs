using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaDbContext db;

        public SeatRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Seat>> GetBookedSeats(int showTimeId, int movieId)
        {
            var seats = db.Seats as IQueryable<Seat>;
            return await seats.Include("Bookings")
                              .Where(s => s.Bookings.Any(b => b.Seat.Screen.ShowTimes.Any(st => st.MovieShowTimes.Any(mt => mt.ShowTimeId == showTimeId && mt.MovieId == movieId)))).ToListAsync();
        }

        public async Task<ICollection<Seat>> GetSeatsForScreen(int screenId)
        {
            var seats = db.Seats as IQueryable<Seat>;
            return await seats.Where(s => s.ScreenId == screenId).ToListAsync();
        }
    }
}
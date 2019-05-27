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

        public async Task<ICollection<Seat>> GetBookedSeats(int movieId, int showTimeId)
        {
            var seats = db.Seats.Include(sb => sb.SeatBookings).ThenInclude(b => b.Booking) as IQueryable<Seat>;
            return await seats.Where(s => s.Screen.ShowTimes.Any(st => st.MovieShowTimes.Any(mt => mt.MovieId == movieId && mt.ShowTimeId == showTimeId))).ToListAsync();
        }

        public async Task<ICollection<Seat>> GetSeatsForScreen(int screenId)
        {
            var seats = db.Seats as IQueryable<Seat>;
            return await seats.Where(s => s.ScreenId == screenId).ToListAsync();
        }
    }
}
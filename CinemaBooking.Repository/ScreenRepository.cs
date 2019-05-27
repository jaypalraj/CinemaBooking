using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Repository
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly CinemaDbContext db;

        public ScreenRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Screen>> GetAllScreensForShowtimeAsync(int showTimeId)
        {
            var screens = db.Screens.Include(s => s.Seats) as IQueryable<Screen>;

            return await screens.Where(s => s.ShowTimes.Any(st => st.ShowTimeId == showTimeId)).ToListAsync();
        }

        public async Task<Screen> GetScreenForMovieAtShowtimeAsync(int movieId, int showTimeId)
        {
            var screens = db.Screens.Include(s => s.Seats) as IQueryable<Screen>;

            return await screens.SingleAsync(s => s.ShowTimes.Any(st => st.MovieShowTimes.Any(mst => mst.MovieId == movieId && mst.ShowTimeId == showTimeId)));
        }
    }
}

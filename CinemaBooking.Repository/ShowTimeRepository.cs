using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Repository
{
    public class ShowTimeRepository : IShowTimeRepository
    {
        private readonly CinemaDbContext db;

        public ShowTimeRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<ShowTime>> GetShowTimesForMovieAsync(int movieId)
        {
            var showTimes = db.ShowTimes.Include(st => st.Screen) as IQueryable<ShowTime>;

            return await showTimes.Where(st => st.MovieShowTimes.Any(m => m.MovieId == movieId)).ToListAsync();
        }
    }
}
using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IEnumerable<ShowTime> GetShowTimesForMovie(int movieId)
        {
            return db.ShowTimes.Where(st => st.MovieShowTimes.Any(m => m.MovieId == movieId));
        }
    }
}

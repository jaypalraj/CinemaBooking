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
    public class GenreRepository : IGenreRepository
    {
        private readonly CinemaDbContext db;

        public GenreRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<Genre>> GetAllGenresAsync()
        {
            var genres = db.Genres as IQueryable<Genre>;

            return await genres.ToListAsync();
        }
    }
}

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
    public class BookingRepository : IBookingRepository
    {
        private readonly CinemaDbContext db;

        public BookingRepository(CinemaDbContext db)
        {
            this.db = db;
        }


        public async Task<Booking> SaveBooking(Booking obj)
        {
            db.Bookings.Add(obj);

            await db.SaveChangesAsync();

            return obj;
        }
    }
}

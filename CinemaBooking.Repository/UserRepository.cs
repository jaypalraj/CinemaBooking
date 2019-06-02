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
    public class UserRepository : IUserRepository
    {
        private readonly CinemaDbContext db;

        public UserRepository(CinemaDbContext db)
        {
            this.db = db;
        }



        public async Task<AppUser> SaveUser(AppUser user)
        {
            db.Add(user);
            await db.SaveChangesAsync();

            return user;
        }
    }
}

using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.WebAPI.Controllers
{
    [Route("[controller]")]
    public class AppUsersController
    {
        private readonly IUserRepository userRepository;

        public AppUsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpPost]
        public async Task<ActionResult<AppUser>> Post([FromBody] AppUser user)
        {
            return await userRepository.SaveUser(user);
        }
    }
}

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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }


        [HttpPost]
        public async Task<ActionResult<Booking>> Post([FromBody] Booking booking)
        {
            return await bookingRepository.SaveBooking(booking);
        }
    }
}

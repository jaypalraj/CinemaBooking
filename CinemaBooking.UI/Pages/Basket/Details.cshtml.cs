using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using CinemaBooking.Infrastructure;
using CinemaBooking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using CinemaBooking.Domain.Entities;
using System.Net.Http;

namespace CinemaBooking.UI.Pages.Basket
{
    public class DetailsModel : PageModel
    {
        private readonly IClientHelper clientHelper;

        public DetailsModel(IClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
        }

        [BindProperty]
        public UserBookingModel UserBooking { get; set; }

        public MovieScreenModel MovieScreen => HttpContext.Session.GetObject<MovieScreenModel>(SessionKeys.sesssionBasketSeats);

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostBuyTickets()
        {
            var newUser = new AppUser()
            {
                Name = UserBooking.User.Name,
                Email = UserBooking.User.Email
            };

            var userContent = await clientHelper.PostAsync("appusers", newUser);
            var user = await userContent.ReadAsAsync<AppUser>();


            foreach (var seatModel in MovieScreen.Screen.Seats)
            {
                var seat = new Seat
                {
                    SeatId = seatModel.SeatId,
                    Title = seatModel.Title
                };

                var newBooking = new Booking()
                {
                    UserId = user.AppUserId,
                    SeatId = seat.SeatId,
                };

                var bookingContent = await clientHelper.PostAsync("Bookings", newBooking);
                var booking = await bookingContent.ReadAsAsync<Booking>();
            }


            return Redirect($"/Basket/Confirmation/{newUser.AppUserId}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaBooking.Domain.Models;
using CinemaBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaBooking.UI.Pages.Screen
{
    public class DetailsModel : PageModel
    {
        private readonly IClientHelper clientHelper;

        [BindProperty]
        public ScreenModel Screen { get; set; }

        public DetailsModel(IClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetSeats(int movieId, int showTimeId)
        {
            var content = await clientHelper.GetAsync($"screens/{movieId}/{showTimeId}");
            Screen = await content.ReadAsAsync<ScreenModel>();

            var contentBookedSeats = await clientHelper.GetAsync($"seats/booked/{movieId}/{showTimeId}");
            var bookedSeats = await contentBookedSeats.ReadAsAsync<SeatModel[]>();

            foreach(var seat in Screen.Seats.Where(s => bookedSeats.Any(bs => bs.SeatId == s.SeatId)))
            {
                seat.IsBooked = true;
            }

            return Page();
        }


        public async Task<IActionResult> OnPost(int movieId)
        {
            var contentMovie = await clientHelper.GetAsync($"movies/{movieId}");
            var Movie = await contentMovie.ReadAsAsync<MovieModel>();

            var movieScreen = new MovieScreenModel()
            {
                Movie = Movie,
                Screen = Screen
            };

            movieScreen.Screen.Seats = Screen.Seats.Where(s => s.IsSelected == true).ToList();
            
            HttpContext.Session.SetObject(SessionKeys.sesssionBasketSeats, movieScreen);

            return Redirect("/Basket/Details");
        }

    }
}
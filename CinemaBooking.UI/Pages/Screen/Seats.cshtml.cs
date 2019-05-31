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

            return Page();
        }


        public IActionResult OnPost()
        {
            var screen = new ScreenModel();
            screen = Screen;
            screen.Seats = Screen.Seats.Where(s => s.IsSelected == true).ToList();
            
            HttpContext.Session.SetObject(SessionKeys.sesssionBasketSeats, screen);

            return Redirect("/Basket/Details");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaBooking.Domain.Models;
using CinemaBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages.Screen
{
    public class DetailsModel : PageModel
    {
        private readonly IClientHelper clientHelper;

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
    }
}
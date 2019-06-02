using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaBooking.Domain.Models;
using CinemaBooking.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages.Movie
{
    public class DetailsModel : PageModel
    {
        private readonly IClientHelper clientHelper;

        public MovieModel Movie { get; set; }

        public DetailsModel(IClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetMovieDetails(int movieId)
        {
            var content = await clientHelper.GetAsync($"movies/{movieId}");
            Movie = await content.ReadAsAsync<MovieModel>();

            return Page();
        }
    }
}
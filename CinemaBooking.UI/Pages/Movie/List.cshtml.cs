using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaBooking.Domain.Models;
using CinemaBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages.Movie
{
    public class ListModel : PageModel
    {
        private readonly IClientHelper clientHelper;

        public MovieModel[] Movies { get; set; }

        public ListModel(IClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
        }

        public async Task OnGet()
        {
            var content = await clientHelper.GetAsync("movies");
            Movies = await content.ReadAsAsync<MovieModel[]>();
        }
    }
}
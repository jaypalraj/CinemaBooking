using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaBooking.Domain.Models;
using CinemaBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaBooking.UI.Pages.Movie
{
    public class ListModel : PageModel
    {
        private readonly IClientHelper clientHelper;

        [BindProperty]
        public int SelectedGenreId { get; set; }
        public SelectList Genres { get; set; }

        public MovieModel[] Movies { get; set; }

        public ListModel(IClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
        }

        public async Task OnGet()
        {
            var contentGenres = await clientHelper.GetAsync("genres");
            var genres = await contentGenres.ReadAsAsync<GenreModel[]>();
            Genres = new SelectList(genres, nameof(GenreModel.GenreId), nameof(GenreModel.Title));

            var content = await clientHelper.GetAsync("movies");
            Movies = await content.ReadAsAsync<MovieModel[]>();
        }

        public async Task<IActionResult> OnPostFilterMovies()
        {
            var content = await clientHelper.GetAsync($"movies/forgenre/{SelectedGenreId}");
            Movies = await content.ReadAsAsync<MovieModel[]>();

            return Page();
        }
    }
}
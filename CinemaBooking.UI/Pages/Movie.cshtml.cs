using CinemaBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CinemaBooking.UI.Views
{
    public class MovieModel : PageModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public MovieModel()
        {
        }

        public void OnGet()
        {
        }
    }
}
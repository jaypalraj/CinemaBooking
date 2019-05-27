using CinemaBooking.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.UI.Views
{
    [Authorize]
    public class MovieModel : PageModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public MovieModel()
        {
        }

        public void OnGet()
        {
        }

        public async Task OnGetSignOutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}
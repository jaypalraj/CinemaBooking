using CinemaBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CinemaBooking.UI.Pages
{
    public class ShowTimeModel : PageModel
    {
        public Movie movie { get; set; }
        public List<ShowTime> showTimes { get; set; }

        public ShowTimeModel()
        {
        }

        public void OnGet(int movieId)
        {
        }
    }
}
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

namespace CinemaBooking.UI.Pages.Basket
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public ScreenModel Screen;

        public void OnGet()
        {
            Screen = HttpContext.Session.GetObject<ScreenModel>(SessionKeys.sesssionBasketSeats);
        }

        public void OnPostBuyTickets()
        {

        }
    }
}
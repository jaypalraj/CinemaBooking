using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages.Seat
{
    [Authorize]
    public class BookingModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetBookSeat(int screenId, int seatId)
        {
            return Page();
        }
    }
}
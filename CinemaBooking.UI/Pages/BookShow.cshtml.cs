using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages
{
    public class BookShowModel : PageModel
    {
        public int ShowTimeId { get; set; }

        public void OnGet(int showTimeId)
        {
            ShowTimeId = showTimeId;
        }
    }
}
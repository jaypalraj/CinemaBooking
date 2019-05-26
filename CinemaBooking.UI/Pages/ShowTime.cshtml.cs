using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Pages
{
    public class ShowTimeModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        private readonly IShowTimeRepository showTimeRepository;

        public Movie movie { get; set; }
        public List<ShowTime> showTimes { get; set; }

        public ShowTimeModel(IMovieRepository movieRepository, IShowTimeRepository showTimeRepository)
        {
            this.movieRepository = movieRepository;
            this.showTimeRepository = showTimeRepository;
        }

        public void OnGet(int movieId)
        {
            movie = movieRepository.GetByMovieId(movieId);
            showTimes = showTimeRepository.GetShowTimesForMovie(movieId)?.ToList();
        }
    }
}
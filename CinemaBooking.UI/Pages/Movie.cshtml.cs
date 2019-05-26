using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.UI.Views
{
    public class MovieModel : PageModel
    {
        private readonly IMovieRepository movieRepository;
        public IEnumerable<Movie> Movies { get; set; }

        public MovieModel(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }




        public void OnGet()
        {
            Movies = movieRepository.GetAllActiveMovies();
        }
    }
}
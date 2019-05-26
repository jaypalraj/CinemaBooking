using AutoMapper;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaBooking.WebAPI.Controllers
{
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<MovieModel[]>> Get()
        {
            try
            {
                var result = await movieRepository.GetAllActiveMoviesAsync();

                return mapper.Map<MovieModel[]>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieModel>> Get(int movieId)
        {
            try
            {
                var result = await movieRepository.GetByMovieIdAsync(movieId);

                if (result == null) return NotFound();

                return mapper.Map<MovieModel>(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ForShowtime/{showTimeId}")]
        public async Task<ActionResult<MovieModel[]>> GetForShowtime(int showTimeId)
        {
            try
            {
                var result = await movieRepository.GetMoviesAtShowTime(showTimeId);

                if (result == null) return NotFound();

                return mapper.Map<MovieModel[]>(result);


            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
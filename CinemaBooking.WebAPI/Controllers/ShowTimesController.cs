using AutoMapper;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CinemaBooking.WebAPI.Controllers
{
    [Route("[controller]")]
    public class ShowtimesController : ControllerBase
    {
        private readonly IShowTimeRepository showTimeRepository;
        private readonly IMapper mapper;

        public ShowtimesController(IShowTimeRepository showTimeRepository, IMapper mapper)
        {
            this.showTimeRepository = showTimeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<ShowTimeModel[]>> Get(int movieId)
        {
            try
            {
                var showTimes = await showTimeRepository.GetShowTimesForMovieAsync(movieId);

                return mapper.Map<ShowTimeModel[]>(showTimes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
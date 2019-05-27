using AutoMapper;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.WebAPI.Controllers
{
    [Route("[controller]")]
    public class ScreensController : ControllerBase
    {
        private readonly IScreenRepository screenRepository;
        private readonly IMapper mapper;

        public ScreensController(IScreenRepository screenRepository, IMapper mapper)
        {
            this.screenRepository = screenRepository;
            this.mapper = mapper;
        }


        [HttpGet("{showTimeId}")]
        public async Task<ActionResult<ScreenModel[]>> Get(int showTimeId)
        {
            try
            {
                var screens = await screenRepository.GetAllScreensForShowtimeAsync(showTimeId);

                return mapper.Map<ScreenModel[]>(screens);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{movieId}/{showTimeId}")]
        public async Task<ActionResult<ScreenModel>> Get(int movieId, int showTimeId)
        {
            try
            {
                var screen = await screenRepository.GetScreenForMovieAtShowtimeAsync(movieId, showTimeId);

                return mapper.Map<ScreenModel>(screen);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

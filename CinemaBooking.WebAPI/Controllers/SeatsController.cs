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
    public class SeatsController : ControllerBase
    {
        private readonly ISeatRepository seatRepository;
        private readonly IMapper mapper;

        public SeatsController(ISeatRepository seatRepository, IMapper mapper)
        {
            this.seatRepository = seatRepository;
            this.mapper = mapper;
        }

        [HttpGet("{screenId}")]
        public async Task<ActionResult<SeatModel[]>> Get(int screenId)
        {
            try
            {
                var seats = await seatRepository.GetSeatsForScreen(screenId);

                return mapper.Map<SeatModel[]>(seats);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Booked/{showTimeId:int}/{movieId:int}")]
        public async Task<ActionResult<SeatModel[]>> GetBookedSeats(int showTimeId, int movieId)
        {
            try
            {
                var bookedSeats = await seatRepository.GetBookedSeats(movieId, showTimeId);

                return mapper.Map<SeatModel[]>(bookedSeats);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
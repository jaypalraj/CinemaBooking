using AutoMapper;
using CinemaBooking.Domain.Interfaces;
using CinemaBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.WebAPI.Controllers
{
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository genreRepository;
        private readonly IMapper mapper;

        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            this.genreRepository = genreRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GenreModel[]>> Get()
        {
            try
            {
                var result = await genreRepository.GetAllGenresAsync();
                return mapper.Map<GenreModel[]>(result);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

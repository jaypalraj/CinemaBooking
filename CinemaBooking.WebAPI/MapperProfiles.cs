using AutoMapper;
using CinemaBooking.Domain.Entities;
using CinemaBooking.Domain.Models;
using System.Linq;

namespace CinemaBooking.WebAPI
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            this.CreateMap<Movie, MovieModel>()
                .ForMember(mm => mm.Genres, m => m.MapFrom(x => x.MovieGenres.Select(s => s.Genre.Title).ToList()))
                .ForMember(mm => mm.ShowDateTimes, m => m.MapFrom(x => x.MovieShowTimes.Select(s => s.ShowTime).ToList()));
        }
    }
}
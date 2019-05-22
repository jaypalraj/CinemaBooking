using CinemaBooking.Data;
using CinemaBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBooking.Tests.Fakes
{
    public class FakeData
    {
        public void SeedInMemoryData(CinemaDbContext _dbContext)
        {
            var genres = new List<Genre>
                {
                    new Genre { Title = "Action" },
                    new Genre { Title = "Sci-Fi" },
                    new Genre { Title = "Romance" },
                    new Genre { Title = "Drama" },
                    new Genre { Title = "Thriller" },
                    new Genre { Title = "Comedy" },
                    new Genre { Title = "Horror" }
                };

            var movies = new List<Movie>
                {
                    new Movie { Title = "Batman Begins" },
                    new Movie { Title = "Inception" },
                    new Movie { Title = "Notebook" },
                    new Movie { Title = "Forest Gump" },
                    new Movie { Title = "Interstaller" },
                    new Movie { Title = "Evil Dead" }
                };

            var genreAction = genres.Single(g => g.Title == "Action");
            var genreThriller = genres.Single(g => g.Title == "Thriller");
            var genreDrama = genres.Single(g => g.Title == "Drama");
            var genreComedy = genres.Single(g => g.Title == "Comedy");
            var genreHorror = genres.Single(g => g.Title == "Horror");

            var batmanBegins = movies.Single(m => m.Title == "Batman Begins");
            var forestGump = movies.Single(m => m.Title == "Forest Gump");
            var evilDead = movies.Single(m => m.Title == "Evil Dead");

            batmanBegins.MovieGenres = new List<MovieGenre>();
            batmanBegins.MovieGenres.AddRange(new List<MovieGenre>
                {
                    new MovieGenre { Movie = batmanBegins, Genre = genreAction },
                    new MovieGenre { Movie = batmanBegins, Genre = genreThriller },
                    new MovieGenre { Movie = batmanBegins, Genre = genreDrama }
                });

            forestGump.MovieGenres = new List<MovieGenre>();
            forestGump.MovieGenres.AddRange(new List<MovieGenre>
                {
                    new MovieGenre { Movie = forestGump, Genre = genreDrama },
                    new MovieGenre { Movie = forestGump, Genre = genreComedy }
                });

            evilDead.MovieGenres = new List<MovieGenre>();
            evilDead.MovieGenres.AddRange(new List<MovieGenre>
                {
                    new MovieGenre { Movie = evilDead, Genre = genreHorror }
                });

            var screens = new List<Screen>
            {
                new Screen { Title = "Screen1" },
                new Screen { Title = "Screen2" },
                new Screen { Title = "Screen3" }
            };

            var screen1 = screens.Single(s => s.Title == "Screen1");
            var screen2 = screens.Single(s => s.Title == "Screen2");
            var screen3 = screens.Single(s => s.Title == "Screen3");

            var showTimes = new List<ShowTime>
            {
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,11,0,0), Screen = screen1 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,14,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,15,0,0), Screen = screen3 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,17,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,19,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,21,0,0), Screen = screen1 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,21,23,0,0), Screen = screen3 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,11,0,0), Screen = screen1 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,14,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,15,0,0), Screen = screen3 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,17,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,19,0,0), Screen = screen2 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,21,0,0), Screen = screen3 },
                new ShowTime { ShowDateTime = new DateTime(2019,05,22,23,0,0), Screen = screen1 }
            };

            var show2111 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 11);
            var show2114 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 14);
            var show2115 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 15);
            var show2117 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 17);
            var show2119 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 19);
            var show2121 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 21);
            var show2123 = showTimes.Single(s => s.ShowDateTime.Day == 21 && s.ShowDateTime.Hour == 23);
            var show2211 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 11);
            var show2214 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 14);
            var show2215 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 15);
            var show2217 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 17);
            var show2219 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 19);
            var show2221 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 21);
            var show2223 = showTimes.Single(s => s.ShowDateTime.Day == 22 && s.ShowDateTime.Hour == 23);


            batmanBegins.MovieShowTimes = new List<MovieShowTime>();
            batmanBegins.MovieShowTimes.AddRange(new List<MovieShowTime>
            {
                new MovieShowTime { Movie = batmanBegins, ShowTime =  show2114},
                new MovieShowTime { Movie = batmanBegins, ShowTime = show2117},
                new MovieShowTime { Movie = batmanBegins, ShowTime = show2121},
                new MovieShowTime { Movie = batmanBegins, ShowTime =  show2214},
                new MovieShowTime { Movie = batmanBegins, ShowTime = show2217},
                new MovieShowTime { Movie = batmanBegins, ShowTime = show2221},
            });

            forestGump.MovieShowTimes = new List<MovieShowTime>();
            forestGump.MovieShowTimes.AddRange(new List<MovieShowTime>
            {
                new MovieShowTime { Movie = forestGump, ShowTime = show2111},
                new MovieShowTime { Movie = forestGump, ShowTime = show2115},
                new MovieShowTime { Movie = forestGump, ShowTime = show2211},
                new MovieShowTime { Movie = forestGump, ShowTime = show2215}
            });


            evilDead.MovieShowTimes = new List<MovieShowTime>();
            evilDead.MovieShowTimes.AddRange(new List<MovieShowTime>
            {
                new MovieShowTime { Movie = evilDead, ShowTime = show2121},
                new MovieShowTime { Movie = evilDead, ShowTime = show2123},
                new MovieShowTime { Movie = evilDead, ShowTime = show2221},
                new MovieShowTime { Movie = evilDead, ShowTime = show2223}
            });






            _dbContext.Movies.AddRange(movies);
            _dbContext.Genres.AddRange(genres);
            _dbContext.ShowTimes.AddRange(showTimes);

            _dbContext.SaveChanges();
        }
    }
}
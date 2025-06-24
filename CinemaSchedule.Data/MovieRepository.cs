using CinemaSchedule.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new()
        {
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Director = "Christopher Nolan",
                Genre = "Sci-Fi",
                Description = "A thief who steals corporate secrets...",
                Sessions = new List<Session>
                {
                    new Session { Id = 1, ShowTime = DateTime.Now.AddHours(2) },
                    new Session { Id = 2, ShowTime = DateTime.Now.AddHours(5) }
                }
            },
            new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Genre = "Drama",
                Description = "Two imprisoned men bond over a number of years...",
                Sessions = new List<Session>
                {
                    new Session { Id = 3, ShowTime = DateTime.Now.AddHours(3) },
                    new Session { Id = 4, ShowTime = DateTime.Now.AddHours(7) }
                }
            }
        };

        public IEnumerable<Movie> GetAllMovies() => _movies;
        public Movie GetMovieById(int id) => _movies.FirstOrDefault(m => m.Id == id);
    }
}

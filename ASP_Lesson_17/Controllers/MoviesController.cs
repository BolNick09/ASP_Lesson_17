using ASP_Lesson_17.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Lesson_17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new()
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

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var moviesWithSessions = _movies.Select(m => new
            {
                m.Id,
                m.Title,
                Sessions = m.Sessions.Select(s => new { s.Id, s.ShowTime })
            });
            return Ok(moviesWithSessions);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
    }
}

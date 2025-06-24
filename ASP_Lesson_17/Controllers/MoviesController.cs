using CinemaSchedule.Core.Models;
using CinemaSchedule.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Lesson_17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            var moviesWithSessions = movies.Select(m => new
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
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
    }
}

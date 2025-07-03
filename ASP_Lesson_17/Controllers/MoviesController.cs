using ASP_Lesson_17.Filters;
using CinemaSchedule.Core.Models;
using CinemaSchedule.Data;
using Microsoft.AspNetCore.Authorization;
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
        [MovieExists]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();

            _movieRepository.UpdateMovie(movie);
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(MovieValidationFilter))]
        public IActionResult AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }
    }
}

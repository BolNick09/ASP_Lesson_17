using CinemaSchedule.Core.Models;
using CinemaSchedule.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Lesson_17.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public EditModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnGet(int id)
        {
            Movie = _movieRepository.GetMovieById(id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _movieRepository.UpdateMovie(Movie);
            return RedirectToPage("/Search/Index");
        }
    }
}

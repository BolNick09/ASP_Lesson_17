using CinemaSchedule.Core.Models;
using CinemaSchedule.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_Lesson_17.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository _movieRepository;

        public IndexModel(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Movies = _movieRepository.SearchMovies(SearchTerm);
            }
        }
    }
}

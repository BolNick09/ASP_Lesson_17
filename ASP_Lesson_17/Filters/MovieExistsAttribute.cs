using CinemaSchedule.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Lesson_17.Filters
{
    public class MovieExistsAttribute : TypeFilterAttribute
    {
        public MovieExistsAttribute() : base(typeof(MovieExistsFilterImpl))
        {
        }

        private class MovieExistsFilterImpl : IActionFilter
        {
            private readonly IMovieRepository _movieRepository;

            public MovieExistsFilterImpl(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ActionArguments.ContainsKey("id"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var id = (int)context.ActionArguments["id"];
                var movie = _movieRepository.GetMovieById(id);
                if (movie == null)
                {
                    context.Result = new NotFoundResult();
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}

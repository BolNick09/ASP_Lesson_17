using CinemaSchedule.Core.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Lesson_17.Filters
{
    public class MovieValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("movie"))
            {
                context.Result = new BadRequestObjectResult("Movie object is required");
                return;
            }

            var movie = context.ActionArguments["movie"] as Movie;
            if (movie == null)
            {
                context.Result = new BadRequestObjectResult("Invalid movie data");
                return;
            }

            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                context.ModelState.AddModelError("Title", "Title is required");
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

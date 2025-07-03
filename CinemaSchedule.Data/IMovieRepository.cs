using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSchedule.Core.Models;

namespace CinemaSchedule.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        IEnumerable<Movie> SearchMovies(string searchTerm);
        void UpdateMovie(Movie movie);
        void AddMovie(Movie movie);
    }
}

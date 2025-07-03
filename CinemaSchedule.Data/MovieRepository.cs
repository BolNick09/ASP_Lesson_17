using CinemaSchedule.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies() =>
            _context.Movies.Include(m => m.Sessions).ToList();

        public Movie GetMovieById(int id) =>
            _context.Movies.Include(m => m.Sessions).FirstOrDefault(m => m.Id == id);

        public IEnumerable<Movie> SearchMovies(string searchTerm) =>
            _context.Movies.Include(m => m.Sessions)
                .Where(m => m.Title.Contains(searchTerm) ||
                       m.Director.Contains(searchTerm) ||
                       m.Genre.Contains(searchTerm) ||
                       m.Description.Contains(searchTerm) ||
                       m.Sessions.Any(s => s.ShowTime.ToString().Contains(searchTerm)))
                .ToList();

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}

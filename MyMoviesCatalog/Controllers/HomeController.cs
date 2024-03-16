using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using MyMoviesCatalog.Models;
using MyMoviesCatalog.ViewModels;
using System.Diagnostics;

namespace MyMoviesCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDataContext context;

        public HomeController(MovieDataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var movies = this.context.Movie.Include(m => m.Styles).Select(m => new MovieViewModel
            {
                Title = m.Title,
                Producer = m.Producer,
                Rating = m.Rating,
                Styles = string.Join(',', m.Styles.Select(a => a.Styles))
            });

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

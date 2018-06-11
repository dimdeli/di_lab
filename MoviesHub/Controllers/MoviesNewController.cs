using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MoviesHub.Models;
using MoviesHub.Models.Interfaces;

namespace MoviesHub.Controllers
{
    public class MoviesNewController : Controller
    {
        private readonly IMovieService movieService_;

        public MoviesNewController(IMovieService movieService)
        {
            movieService_ = movieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await movieService_.GetAllAsync();

            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await movieService_.GetAsync(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}

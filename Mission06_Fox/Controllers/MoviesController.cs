using Microsoft.AspNetCore.Mvc;
using Mission06_Fox.Models;

namespace Mission06_Fox.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext _context;

        public MoviesController(MovieContext temp)
        {
            _context = temp;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                return View(response);
            }
        }
    }
}
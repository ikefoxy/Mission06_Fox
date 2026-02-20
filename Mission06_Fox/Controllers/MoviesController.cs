using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Fox.Models;

namespace Mission06_Fox.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext temp)
        {
            _context = temp;
        }

        // -------------------------
        // CREATE
        // -------------------------
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
                // DB columns are NOT NULL, but model is bool?
                response.Edited = response.Edited ?? false;
                response.CopiedToPlex = response.CopiedToPlex ?? false;

                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }

            return View(response);
        }

        // -------------------------
        // LIST
        // -------------------------
        [HttpGet]
        public IActionResult List()
        {
            var movies = _context.Movies
                .AsNoTracking()
                .OrderBy(m => m.Title)
                .ToList();

            return View(movies);
        }

        // -------------------------
        // EDIT
        // -------------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                // DB columns are NOT NULL, but model is bool?
                updatedMovie.Edited = updatedMovie.Edited ?? false;
                updatedMovie.CopiedToPlex = updatedMovie.CopiedToPlex ?? false;

                _context.Movies.Update(updatedMovie);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            return View(updatedMovie);
        }

        // -------------------------
        // DELETE
        // -------------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .AsNoTracking()
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == MovieId);

            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("List");
        }
    }
}
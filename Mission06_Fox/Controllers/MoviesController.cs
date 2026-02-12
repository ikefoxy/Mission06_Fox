using Microsoft.AspNetCore.Mvc;

namespace Mission06_Fox.Controllers;

public class MoviesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Fox.Models;

namespace Mission06_Fox.Controllers;

public class HomeController : Controller
{
    // Home page
    public IActionResult Index()
    {
        return View();
    }

    // Get to Know Joel page
    public IActionResult Joel()
    {
        return View();
    }

    // Default error handler (keep this)
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzMvc.Models;
using FizzBuzzLibrary;

namespace FizzBuzzMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult FizzBuzz(int? number)
    {
        FizzBuzzLogic fb = new FizzBuzzLogic();
        string? output = fb.GetOutput(number);
        ViewData["Output"] = output;
        ViewBag.Output = output;
        return View("Index");
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

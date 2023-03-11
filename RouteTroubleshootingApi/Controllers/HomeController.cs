using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RouteTroubleshootingApi.Models;

namespace RouteTroubleshootingApi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        this.configuration = configuration;
    }

    public IActionResult Index()
    {
        this.ViewData["APP_NAME"] = configuration.GetValue<string>("APP_NAME");
        this.ViewData["MACHINE_NAME"] = Environment.MachineName;
        this.ViewData["REQUEST_HOST"] = Request.Host.Value;
        this.ViewData["REQUEST_PATH"] = Request.Path;
        
        return View();
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

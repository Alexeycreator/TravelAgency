using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly TravelAgencyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, TravelAgencyContext context)
    {
      _logger = logger;
      _context = context;
    }

    public IActionResult Index()
    {
      var country = _context.Countries.ToList();
      return View(country);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

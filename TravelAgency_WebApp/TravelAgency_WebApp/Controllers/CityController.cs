using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class CityController : Controller
  {

    private readonly TravelAgencyContext _context;

    public CityController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: CityController
    public ActionResult Index()
    {
      var city = _context.Cities.ToList();
      return View(city);
    }

    // GET: CityController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: CityController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: CityController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(City city)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(city);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(city);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var city = await _context.Cities.FindAsync(id);
      if (city == null)
      {
        return NotFound();
      }
      return View(city);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, City city)
    {
      try
      {
        if (id != city.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(city);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!CityExists(city.Id))
            {
              return NotFound();
            }
            else
            {
              throw;
            }
          }
          return RedirectToAction(nameof(Index));
        }
        return View(city);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var city = await _context.Cities
          .FirstOrDefaultAsync(m => m.Id == id);
      if (city == null)
      {
        return NotFound();
      }

      return View(city);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var city = await _context.Cities.FindAsync(id);
      if (city != null)
      {
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool CityExists(int id)
    {
      return _context.Cities.Any(e => e.Id == id);
    }
  }
}

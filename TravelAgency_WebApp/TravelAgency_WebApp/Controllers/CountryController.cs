using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class CountryController : Controller
  {
    // GET: CountryController
    private readonly TravelAgencyContext _context;

    public CountryController(TravelAgencyContext context)
    {
      _context = context;
    }

    public ActionResult Index()
    {
      var counties = _context.Countries.ToList();
      return View(counties);
    }

    // GET: CountryController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: CountryController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: CountryController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Country country)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(country);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(country);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var country = await _context.Countries.FindAsync(id);
      if (country == null)
      {
        return NotFound();
      }
      return View(country);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Country country)
    {
      try
      {
        if (id != country.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(country);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!CountryExists(country.Id))
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
        return View(country);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var country = await _context.Countries
          .FirstOrDefaultAsync(m => m.Id == id);
      if (country == null)
      {
        return NotFound();
      }

      return View(country);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var country = await _context.Countries.FindAsync(id);
      if (country != null)
      {
        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool CountryExists(int id)
    {
      return _context.Countries.Any(e => e.Id == id);
    }
  }
}

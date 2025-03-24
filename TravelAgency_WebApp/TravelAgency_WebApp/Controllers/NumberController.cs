using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class NumberController : Controller
  {
    private readonly TravelAgencyContext _context;

    public NumberController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: NumberController
    public ActionResult Index()
    {
      var number = _context.Numbers.ToList();
      return View(number);
    }

    // GET: NumberController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: NumberController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: NumberController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Number number)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(number);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(number);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var number = await _context.Numbers.FindAsync(id);
      if (number == null)
      {
        return NotFound();
      }
      return View(number);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Number number)
    {
      try
      {
        if (id != number.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(number);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!NumberExists(number.Id))
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
        return View(number);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var hotel = await _context.Numbers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (hotel == null)
      {
        return NotFound();
      }

      return View(hotel);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var number = await _context.Numbers.FindAsync(id);
      if (number != null)
      {
        _context.Numbers.Remove(number);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool NumberExists(int id)
    {
      return _context.Numbers.Any(e => e.Id == id);
    }
  }
}

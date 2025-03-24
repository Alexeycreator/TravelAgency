using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class HotelController : Controller
  {
    private readonly TravelAgencyContext _context;

    public HotelController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: HotelController
    public ActionResult Index()
    {
      var hotel = _context.Hotels.ToList();
      return View(hotel);
    }

    // GET: HotelController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: HotelController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: HotelController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Hotel hotel)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(hotel);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(hotel);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var hotel = await _context.Hotels.FindAsync(id);
      if (hotel == null)
      {
        return NotFound();
      }
      return View(hotel);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Hotel hotel)
    {
      try
      {
        if (id != hotel.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!HotelExists(hotel.Id))
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
        return View(hotel);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var hotel = await _context.Hotels
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
      var hotel = await _context.Hotels.FindAsync(id);
      if (hotel != null)
      {
        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool HotelExists(int id)
    {
      return _context.Hotels.Any(e => e.Id == id);
    }
  }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class BookTourController : Controller
  {
    private readonly TravelAgencyContext _context;

    public BookTourController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: BookTourController
    public ActionResult Index()
    {
      var bookTour = _context.BookTours.ToList();
      return View(bookTour);
    }

    // GET: BookTourController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: BookTourController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: BookTourController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BookTour bookTour)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(bookTour);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(bookTour);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var bookTour = await _context.BookTours.FindAsync(id);
      if (bookTour == null)
      {
        return NotFound();
      }
      return View(bookTour);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BookTour bookTour)
    {
      try
      {
        if (id != bookTour.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(bookTour);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!BookTourExists(bookTour.Id))
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
        return View(bookTour);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var bookTour = await _context.BookTours
          .FirstOrDefaultAsync(m => m.Id == id);
      if (bookTour == null)
      {
        return NotFound();
      }

      return View(bookTour);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var bookTour = await _context.BookTours.FindAsync(id);
      if (bookTour != null)
      {
        _context.BookTours.Remove(bookTour);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool BookTourExists(int id)
    {
      return _context.BookTours.Any(e => e.Id == id);
    }
  }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class ResidenceController : Controller
  {
    private readonly TravelAgencyContext _context;

    public ResidenceController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: ResidenceController
    public ActionResult Index()
    {
      var residence = _context.Residences.ToList();
      return View(residence);
    }

    // GET: ResidenceController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: ResidenceController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: ResidenceController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Residence residence)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(residence);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(residence);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var residence = await _context.Residences.FindAsync(id);
      if (residence == null)
      {
        return NotFound();
      }
      return View(residence);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Residence residence)
    {
      try
      {
        if ((id != residence.BookTour_Id) || (id != residence.Number_Id))
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(residence);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!ResidenceExists(residence.BookTour_Id))
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
        return View(residence);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var residence = await _context.Residences
          .FirstOrDefaultAsync(m => m.BookTour_Id == id || m.Number_Id == id);
      if (residence == null)
      {
        return NotFound();
      }

      return View(residence);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var residence = await _context.Residences.FindAsync(id);
      if (residence != null)
      {
        _context.Residences.Remove(residence);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool ResidenceExists(int id)
    {
      return _context.Residences.Any(e => e.BookTour_Id == id || e.Number_Id == id);
    }
  }
}

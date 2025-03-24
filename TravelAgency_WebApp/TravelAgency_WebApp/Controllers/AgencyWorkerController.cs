using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class AgencyWorkerController : Controller
  {

    private readonly TravelAgencyContext _context;

    public AgencyWorkerController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: AgencyWorkerController
    public ActionResult Index()
    {
      var agencyWorker = _context.AgencyWorkers.ToList();
      return View(agencyWorker);
    }

    // GET: AgencyWorkerController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: AgencyWorkerController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: AgencyWorkerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AgencyWorker agencyWorker)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(agencyWorker);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(agencyWorker);
      }
      catch
      {
        return View();
      }
    }

    // GET: AgencyWorkerController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var agencyWorker = await _context.AgencyWorkers.FindAsync(id);
      if (agencyWorker == null)
      {
        return NotFound();
      }
      return View(agencyWorker);
    }

    // POST: AgencyWorkerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AgencyWorker agencyWorker)
    {
      try
      {
        if (id != agencyWorker.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(agencyWorker);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!AgencyWorkerExists(agencyWorker.Id))
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
        return View(agencyWorker);
      }
      catch
      {
        return View();
      }
    }

    // GET: AgencyWorkerController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var agencyWorker = await _context.AgencyWorkers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (agencyWorker == null)
      {
        return NotFound();
      }

      return View(agencyWorker);
    }

    // POST: AgencyWorkerController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var agencyWorker = await _context.AgencyWorkers.FindAsync(id);
      if (agencyWorker != null)
      {
        _context.AgencyWorkers.Remove(agencyWorker);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool AgencyWorkerExists(int id)
    {
      return _context.Countries.Any(e => e.Id == id);
    }
  }
}

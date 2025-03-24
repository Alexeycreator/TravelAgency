using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgency_WebApp.Models;

namespace TravelAgency_WebApp.Controllers
{
  public class ClientController : Controller
  {
    private readonly TravelAgencyContext _context;

    public ClientController(TravelAgencyContext context)
    {
      _context = context;
    }

    // GET: ClientController
    public ActionResult Index()
    {
      var client = _context.Clients.ToList();
      return View(client);
    }

    // GET: ClientController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: ClientController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: ClientController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Client client)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _context.Add(client);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
        return View(client);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var client = await _context.Clients.FindAsync(id);
      if (client == null)
      {
        return NotFound();
      }
      return View(client);
    }

    // POST: CountryController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Client client)
    {
      try
      {
        if (id != client.Id)
        {
          return NotFound();
        }

        if (ModelState.IsValid)
        {
          try
          {
            _context.Update(client);
            await _context.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!ClientExists(client.Id))
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
        return View(client);
      }
      catch
      {
        return View();
      }
    }

    // GET: CountryController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var client = await _context.Clients
          .FirstOrDefaultAsync(m => m.Id == id);
      if (client == null)
      {
        return NotFound();
      }

      return View(client);
    }

    // POST: CountryController/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var client = await _context.Clients.FindAsync(id);
      if (client != null)
      {
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
      }
      return RedirectToAction(nameof(Index));
    }

    private bool ClientExists(int id)
    {
      return _context.Clients.Any(e => e.Id == id);
    }
  }
}

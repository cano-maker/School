using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Web.Data;
using School.Web.Models;

namespace School.Web.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Neighborhoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Neighborhoods.ToListAsync());
        }

        // GET: Neighborhoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return View(neighborhood);
        }

        // GET: Neighborhoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Neighborhoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(neighborhood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(neighborhood);
        }

        // GET: Neighborhoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            return View(neighborhood);
        }

        // POST: Neighborhoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Neighborhood neighborhood)
        {
            if (id != neighborhood.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                       dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(neighborhood);
        }
        // GET: Neighborhoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Neighborhood neighborhood = await _context.Neighborhoods
            .FirstOrDefaultAsync(m => m.Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteNeighborhood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Neighborhood neighborhood = await _context.Neighborhoods
                .Include(d => d.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            City city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Neighborhoods.FirstOrDefault(n => n.Id == neighborhood.Id) != null);
            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();
            //return RedirectToAction($"{nameof(Details)}/{country.Id}");
            return RedirectToAction($"{nameof(Details)}","Cities", new { id = city.Id });
        }

        // POST: Neighborhoods/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var neighborhood = await _context.Neighborhoods.FindAsync(id);
        //    _context.Neighborhoods.Remove(neighborhood);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool NeighborhoodExists(int id)
        {
            return _context.Neighborhoods.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddNeighborhood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            City city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            Neighborhood model = new Neighborhood { IdCity = city.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNeighborhood(Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                City city = await _context.Cities
                .Include(c => c.Neighborhoods)
                .FirstOrDefaultAsync(c => c.Id == neighborhood.IdCity);
                if (city == null)
                {
                    return NotFound();
                }
                try
                {
                    neighborhood.Id = 0;
                    city.Neighborhoods.Add(neighborhood);
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}", "Cities", new { id = city.Id });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(neighborhood);
        }

        public async Task<IActionResult> EditNeighborhood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Neighborhood neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            City city = await _context.Cities.FirstOrDefaultAsync(c => c.Neighborhoods.FirstOrDefault(n => n.Id == neighborhood.Id) != null);
            neighborhood.IdCity = city.Id;
            return View(neighborhood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNeighborhood(Neighborhood neighborhood)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neighborhood);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details),"Cities", new { id = neighborhood.IdCity }); ;
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(neighborhood);
        }

    }
}

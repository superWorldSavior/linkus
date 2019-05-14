using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using linkus_tv;
using linkus_tv.Models;

namespace linkus_tv.Controllers
{
    public class cartesController : Controller
    {
        private readonly linkus_tvContext _context;

        public cartesController(linkus_tvContext context)
        {
            _context = context;
        }

        // GET: cartes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carte.ToListAsync());
        }

        // GET: cartes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carte = await _context.Carte
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carte == null)
            {
                return NotFound();
            }

            return View(carte);
        }

        // GET: cartes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cartes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Boisson,Prix")] carte carte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carte);
        }

        // GET: cartes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carte = await _context.Carte.SingleOrDefaultAsync(m => m.Id == id);
            if (carte == null)
            {
                return NotFound();
            }
            return View(carte);
        }

        // POST: cartes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Boisson,Prix")] carte carte)
        {
            if (id != carte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carteExists(carte.Id))
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
            return View(carte);
        }

        // GET: cartes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carte = await _context.Carte
                .SingleOrDefaultAsync(m => m.Id == id);
            if (carte == null)
            {
                return NotFound();
            }

            return View(carte);
        }

        // POST: cartes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var carte = await _context.Carte.SingleOrDefaultAsync(m => m.Id == id);
            _context.Carte.Remove(carte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carteExists(long id)
        {
            return _context.Carte.Any(e => e.Id == id);
        }
    }
}

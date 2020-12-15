using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Data;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    public class SuperHerosController : Controller
    {
        //member variable
        private ApplicationDbContext _context;

        //constructor
        public SuperHerosController(ApplicationDbContext context)
        {
            _context = context; 
        }
        // GET: SuperHerosController
        public async Task<IActionResult> Index()
        {
            return View(await _context.superHero.ToListAsync());
        }

        // GET: SuperHerosController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.superHero
                .FirstOrDefaultAsync(m => m.ID == id);
            if (superHero == null)
            {
                return NotFound();
            }

            return View(superHero);
        }

        // GET: SuperHerosController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperHerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,PrimaryAbility,SecondaryAbility,CatchPhrase,AlterEgo")] SuperHero superHero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHero);
        }

        // GET: SuperHerosController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.superHero.FindAsync(id);
            if (superHero == null)
            {
                return NotFound();
            }
            return View(superHero);
        }

        // POST: SuperHerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,PrimaryAbility,SecondaryAbility,CatchPhrase,AlterEgo")] SuperHero superHero)
        {
            if (id != superHero.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperHeroExists(superHero.ID))
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
            return View(superHero);
        }

        // GET: SuperHerosController/Delete/5
         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superHero = await _context.superHero
                .FirstOrDefaultAsync(m => m.ID == id);
            if (superHero == null)
            {
                return NotFound();
            }

            return View(superHero);
        }

        // POST: SuperHerosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superHero = await _context.superHero.FindAsync(id);
            _context.superHero.Remove(superHero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperHeroExists(int id)
        {
            return _context.superHero.Any(e => e.ID == id);
        }
    }
}

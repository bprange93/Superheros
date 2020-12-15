using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeros.Data;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    public class SuperHerosController : Controller
    {
        private ApplicationDbContext _context;
        public SuperHerosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperHerosController
        public ActionResult Index()
        {
            return View(_context.SuperHeros.ToList());
        }

        // GET: SuperHerosController/Details/5
        public ActionResult Details(int id)
        {
            var CurrentHero = _context.SuperHeros.Find(id);
            return View(CurrentHero);
        }

        // GET: SuperHerosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                _context.SuperHeros.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHerosController/Edit/5
        public ActionResult Edit(int id)
        {
            var CurrentHero = _context.SuperHeros.Find(id);
            return View(CurrentHero);
        }

        // POST: SuperHerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHero)
        {
            try
            {
                _context.SuperHeros.Update(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHerosController/Delete/5
        public ActionResult Delete(int id)
        {
            var CurrentHero = _context.SuperHeros.Find(id);
            return View(CurrentHero);
        }

        // POST: SuperHerosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                var DeleteHero = _context.SuperHeros.Find(id);
                _context.SuperHeros.Remove(DeleteHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

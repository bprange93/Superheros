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
        //member variable
        private ApplicationDbContext _db;

        //constructor
        public SuperHerosController(ApplicationDbContext db)
        {
            _db = db; 
        }
        // GET: SuperHerosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SuperHerosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: SuperHerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
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
            return View();
        }

        // POST: SuperHerosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

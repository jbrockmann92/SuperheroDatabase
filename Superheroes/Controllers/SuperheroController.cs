using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superhero
        public ActionResult Index()
        {
            return View(_context.Superheroes.ToList());
            //Will return the html page called Index from the Views/Superhero folder??
            //Returns the homepage?
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            var hero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
            //Need to get working so that I can click on his name, not the Details button
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Superheroes.Add(superhero);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }

            ViewBag.SuperHeroId = new SelectList(_context.Superheroes);
            return View();
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            //Want to bring superhero out of db, make changes using Create(), then put back?
            //No, just want to take whatever changes they make and update the row in the db
            //Do check boxes to see what they want to change? Then put those on the screen?
            return View();
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            _context.Superheroes.Remove(hero);
            _context.SaveChanges();
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
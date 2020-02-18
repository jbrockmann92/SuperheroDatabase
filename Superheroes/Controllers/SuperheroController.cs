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

        public ActionResult Index()
        {
            return View(_context.Superheroes.ToList());
        }

        public ActionResult Details(int id)
        {
            var hero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(hero);
        }

        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

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

        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(superhero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
                if (ModelState.IsValid)
                {
                    _context.Superheroes.Update(superhero);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
        }

        public ActionResult Delete(int id)
        {
            var hero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            _context.Superheroes.Remove(hero);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
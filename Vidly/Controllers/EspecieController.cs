using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewsModels;

namespace Vidly.Controllers
{
    public class EspecieController : Controller
    {
        //
        // GET: /Especie/
        private ApplicationDbContext _context;
        public EspecieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var especie = _context.Especie.ToList();
            return View(especie);
        }
        public ActionResult Details(int Id)
        {
            var especies = _context.Especie.SingleOrDefault(c => c.id == Id);


            if (especies == null)
                return HttpNotFound();

            return View(especies);
        }
        public ActionResult Edit(int id)
        {
            var especie = _context.Especie.SingleOrDefault(c => c.id == id);

            if (especie == null)
                return HttpNotFound();

            var viewModel = new EspecieFormViewModels
            {
                Especie = especie

            };
            
            return View("EspecieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Species especie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EspecieFormViewModels
                {
                    Especie = especie
                };

                return View("EspecieForm", viewModel);
            }
         
            if (especie.id == 0)
            {
                _context.Especie.Add(especie);
            }
            else
            {
                var especieInDb = _context.Especie.Single(c => c.id == especie.id);

                especieInDb.nome = especie.nome;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult New()
        {

            var viewModel = new EspecieFormViewModels
            {
                Especie = new Species()
            };

            return View("EspecieForm", viewModel);
        }
         public ActionResult Delete(int id)
        {
            var especie = _context.Especie.SingleOrDefault(c => c.id == id);

            if (especie == null)
                return HttpNotFound();

            _context.Especie.Remove(especie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
       
	}
}
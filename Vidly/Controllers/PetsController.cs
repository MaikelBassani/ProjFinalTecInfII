using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewsModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class PetsController : Controller
    {
        private ApplicationDbContext _context;
        public PetsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var pets = _context.Pet.Include(c => c.cliente).Include(c => c.Especie).ToList();
            return View(pets);
        }
        public ActionResult Details(int Id)
        {
            var pets = _context.Pet.SingleOrDefault(c => c.id == Id);


            if (pets == null)
                return HttpNotFound();

            return View(pets);
        }
        public ActionResult Edit(int id)
        {
            var pet = _context.Pet.SingleOrDefault(c => c.id == id);

            if (pet == null)
                return HttpNotFound();

            var especie = _context.Especie.ToList();
            var cliente = _context.Customers.ToList();
            var viewModel = new PetFormViewModels
            {
                Pet = pet,
                Especie = especie,
                cliente = cliente
            };

            return View("PetForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Pet pet)
        {
            Response.Write("<script>alert('" + pet.nome + "')</script>");
            if (!ModelState.IsValid)
            {
                var viewModel = new PetFormViewModels
                {
                    Pet = pet,
                    Especie = _context.Especie.ToList(),
                    cliente = _context.Customers.ToList()
                };

                return View("PetForm", viewModel);
            }
            
            if (pet.id == 0)
            {
                _context.Pet.Add(pet);
            }
            else
            {
                var petInDb = _context.Pet.Single(c => c.id == pet.id);

                petInDb.nome = pet.nome;
                petInDb.raca = pet.raca;
                petInDb.cor = pet.cor;
                petInDb.EspecieId = pet.EspecieId;
                petInDb.ClienteId = pet.ClienteId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult New()
        {
            var especie = _context.Especie.ToList();
            var cliente = _context.Customers.ToList();
            var viewModel = new PetFormViewModels
            {
                Pet = new Pet(),
                Especie = especie,
                cliente = cliente
            };

            return View("PetForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var pet = _context.Pet.SingleOrDefault(c => c.id == id);

            if (pet == null)
                return HttpNotFound();

            _context.Pet.Remove(pet);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        

        
    }
}
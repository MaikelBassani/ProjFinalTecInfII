using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewsModels;

namespace Vidly.Controllers
{
    public class PetsController : Controller
    {
        public IEnumerable<Pet> GetPets()
        {
            return new List<Pet>
            {
                new Pet { nome = "Yorkshire", id = 1},
                new Pet {nome = "Pastor Alemão", id = 2}
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var pets = new Pet() { nome = "Nada!" };

            var customers = new List<Customer>
            {
                new Customer {nome = "Customer 1"},
                new Customer {nome = "Customer 2"}
            };

            var viewModel = new RandomPetsViewModel
            {
                Pets = pets,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var animal = GetPets();

            return View(animal);
        }
    }
}
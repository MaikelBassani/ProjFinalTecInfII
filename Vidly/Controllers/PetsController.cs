using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
            var pets = _context.Pet.ToList();
            return View(pets);
        }
        public ActionResult Details(int Id)
        {
            var pets = _context.Pet.SingleOrDefault(c => c.id == Id);


            if (pets == null)
                return HttpNotFound();

            return View(pets);
        }

        

        
    }
}
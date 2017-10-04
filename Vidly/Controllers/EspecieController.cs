using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
	}
}
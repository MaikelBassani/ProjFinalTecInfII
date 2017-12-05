using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewsModels;

namespace Vidly.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
         private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var produto = _context.Produto.ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(produto);

            return View("ReadOnlyIndex", produto);
        }
        public ActionResult Details(int Id)
        {
            var produto = _context.Produto.SingleOrDefault(c => c.id == Id);


            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var produto = _context.Produto.SingleOrDefault(c => c.id == id);

            if (produto == null)
                return HttpNotFound();

            var viewModel = new ProdutoFormViewModel
            {
                Produto = produto
            };

            return View("ProductForm", viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Save(Product produto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel
                {
                    Produto = produto
                };

                return View("ProductForm", viewModel);
            }

            if (produto.id == 0)
            {
                _context.Produto.Add(produto);
            }
            else
            {
                var produtoInDb = _context.Produto.Single(c => c.id == produto.id);

                produtoInDb.nome = produto.nome;
                produtoInDb.quant = produto.quant;
                produtoInDb.preco = produto.preco;
                produtoInDb.descricao = produto.descricao;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult New()
        {
            var viewModel = new ProdutoFormViewModel
            {
                Produto = new Product()
            };

            return View("ProductForm", viewModel);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produto.SingleOrDefault(c => c.id == id);

            if (produto == null)
                return HttpNotFound();

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
	}
}
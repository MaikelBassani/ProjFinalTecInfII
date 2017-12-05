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
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(customer);

            return View("ReadOnlyIndex", customer);
        }
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == Id);


            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer

            };

            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);

                customerInDb.nome = customer.nome;
                customerInDb.cpf = customer.cpf;
                customerInDb.endereco = customer.endereco;
                customerInDb.bairro = customer.bairro;
                customerInDb.num_casa = customer.num_casa;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult New()
        {

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
       
	}
}
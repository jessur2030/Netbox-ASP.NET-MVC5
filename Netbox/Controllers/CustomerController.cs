using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netbox.Models;
using Netbox.ViewModels;
using System.Data.Entity;
using Netbox.Migrations;

namespace Netbox.Controllers
{

    public class CustomerController : Controller
    {
        //
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()

        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        //Add & Edit Customers from Db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)

            _context.Customer.Add(customer);

            else
            {
                var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);   //NOTE: This is the official aprouch from Microsoft .net to apdate model from Db
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer
        //-----------This Method was replace by customer API-----------//
        //public ViewResult Index()
        //{
        //    var customers = _context.Customer.Include(c => c.MembershipType).ToList();



        //    return View(customers);
        //}

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                   MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


    }
}
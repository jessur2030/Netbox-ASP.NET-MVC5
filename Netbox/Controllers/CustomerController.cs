using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netbox.Models;
using Netbox.ViewModels;
using System.Data.Entity;

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
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();



            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }


    }
}
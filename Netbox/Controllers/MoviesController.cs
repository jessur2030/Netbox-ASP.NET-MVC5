using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Netbox.Models;
using Netbox.ViewModels;

namespace Netbox.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var custumers = new List<Customer>
            {
                 new Customer { Name = "Customer 1"},
                 new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = custumers
            };

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            return View(viewModel);
            //return new ViewResult();
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });

        }

        public ActionResult Customers()
        {
            ViewBag.Message = "Your contact page.";

            var custumers = new List<Customer>
            {
                 new Customer { Name = "Customer 1"},
                 new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
            
                Customers = custumers
            };

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            return View(viewModel);


        }

        public ActionResult Movies()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Edit (int id)
        //{
        //    return Content("id=" + id);
        //}

        ////movies
        //public ActionResult Index (int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}


        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
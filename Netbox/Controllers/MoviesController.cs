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
    public class MoviesController : Controller
    {


        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
                return View("ReadOnlyList");
        }

        //public ViewResult Index()
        //{
        //    var movies = _context.Movies.Include(m => m.Genre).ToList();


        //    return View(movies);
        //}

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                //Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            //var membershipTypes = _context.MembershipTypes.ToList();
            //var viewModel = new NewCustomerViewModel
            //{
            //    MembershipTypes = membershipTypes
            //};
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    //Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id == 0) { 
            movie.DateAdded = DateTime.Now;
        
            _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
  
            return RedirectToAction("Index", "Movies");

     
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Netbox.Dtos;
using Netbox.Models;

namespace Netbox.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customer.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
            //[HttpPost]
            //public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
            //{
            //    //if (newRental.MovieIds.Count == 0)
            //    //    return BadRequest("No Movie ids have been giving.");
            //    var customer = _context.Customer.Single(
            //        c => c.Id == newRental.CustomerId);
            //    //        var customer = _context.Customer.SingleOrDefault(
            //    //c => c.Id == newRental.CustomerId);

            //    //if (customer == null)
            //    //    return BadRequest("CustomerId is not valid.");

            //    var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //    //if (movies.Count != newRental.MovieIds.Count)
            //    //    return BadRequest("One or MovieIds are invalid.");

            //        foreach (var movie in movies)
            //    {
            //        if (movie.NumberAvailable == 0)
            //            return BadRequest("Movie is not available.");
            //        movie.NumberAvailable--;

            //        var rental = new Rental
            //        {
            //            Customer = customer,
            //            Movie = movie,
            //            DateRented = DateTime.Now
            //        };

            //        _context.Rentals.Add(rental);
            //    }
            //    _context.SaveChanges();
            //    return Ok();
            //}



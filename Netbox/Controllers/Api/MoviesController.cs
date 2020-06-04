using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Netbox.Models;
using Netbox.Dtos;
using AutoMapper;

namespace Netbox.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        //public IHttpActionResult GetMovies()
        //{


        // var moviesDto =  _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        //    return  Ok(moviesDto);
        //}

        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }


        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        //[Route("api/movies/{id}")]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            movieDto.DateAdded = movieInDb.DateAdded;

            Mapper.Map(movieDto, movieInDb);

            //movieInDb.Name = movieDto.Name;
            //movieInDb.ReleaseDate = movieDto.ReleaseDate;
            //movieInDb.GenreId = movieDto.GenreId;
            //movieInDb.NumberInStock = movieDto.NumberInStock;

            _context.SaveChanges();
            return Ok();
        }


        // DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

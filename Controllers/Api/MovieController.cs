using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.App_Start;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context=new ApplicationDbContext();
        }
        //GET api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
           return _context.Movies.
                Include(m=>m.Genre).
                ToList().
                Select(Mapper.Map<Movie, MovieDto>);
          
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreatMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT /api/movies
        [HttpPut]
        public Movie UpdateMovie(int id, MovieDto movieDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return movieInDb;
        }
        //DELETE /api/movies
        [HttpDelete]
        public Movie DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return movieInDb;
        }
    }
}

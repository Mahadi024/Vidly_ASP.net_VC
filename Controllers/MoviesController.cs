using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _Context;

        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        public ViewResult Index()
        {
            //var movies = _Context.Movies.Include(m=>m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _Context.Genres.ToList()
                };
                return View("NewMovie", viewModel);
            }
            if (movie.Id==0)
            {
                 movie.AddedTime = DateTime.Now;
                _Context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _Context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
            }

            _Context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Details(int id)
        {
            var movie = _Context.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var genre = _Context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };
            return View("NewMovie",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movies = _Context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies==null)
            {
                return HttpNotFound();
            }
            var viewModel=new MovieFormViewModel(movies)
            {
                Genres = _Context.Genres.ToList()
            };
            return View("NewMovie", viewModel);
        }
        // GET: Movies
        
        //public ActionResult Random()
        //{
        //    var movie = new Movie() {Name = "Shreak!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}

        //    };
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}

        public object model { get; set; }
    }
}
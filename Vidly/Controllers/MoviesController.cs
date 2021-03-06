﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;


namespace Vidly.Controllers
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
            base.Dispose(disposing);
        }

        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");

            }
                return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres

            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);

        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "SAW" },
                new Movie { Id = 2, Name = "Watchmen" }

            };
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }









    //// GET: Movies/Random
    // GET: Movies/Random
    //public ActionResult Random()
    //{
    //    var movie = new Movie() { Name = "IT!" };
    //    var customers = new List<Customer>
    //    {
    //        new Customer { Name = "Customer 1" },
    //        new Customer { Name = "Customer 2" }
    //    };

    //    var viewModel = new RandomMovieViewModel
    //    {
    //        Movie = movie,
    //        Customers = customers
    //    };

    //    return View(viewModel);
    //}

    ////movies
    //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
    //public ActionResult Index(int? pageIndex, string sortBy)
    //{
    //    if (!pageIndex.HasValue)
    //    {
    //        pageIndex = 1;
    //    }

    //    // bool sort = sortBy.IsNullOrWhiteSpace();
    //    if (sortBy.IsNullOrWhiteSpace())
    //    {
    //        sortBy = "Name";
    //    }

    //    return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
    //}

    //public ActionResult ByReleaseDate(int year, int month)
    //{

    //    return Content(year + "/" + month);
    //}

}
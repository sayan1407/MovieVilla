using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieVilla.Models;
using System.Data.Entity;
using AutoMapper;

namespace MovieVilla.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = Role.canManageMovies)]
        public ActionResult EditMovies(int? id)
        {
            Movie movie;

            if (id == null)
            {
                movie = new Movie()
                {
                    Id = 0
                };

                return View(movie);

            }

            movie = db.Movies.Single(m => m.Id == id);
            return View(movie);

        }
        [HttpPost]
        public ActionResult SaveMovies(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            if (movie.Id == 0)
            {
                db.Movies.Add(movie);

            }
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
                Mapper.Map(movie, movieInDb);
            }

            db.SaveChanges();
            return View("MoviesList");
        }
        public ActionResult MoviesList()
        {
            if(User.IsInRole(Role.canManageMovies))
              return View("MoviesList");
            return View("ReadOnlyMoviesList");
        }
    }
}
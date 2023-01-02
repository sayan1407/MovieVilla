using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieVilla.Models;

namespace MovieVilla.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext Db = new ApplicationDbContext();
        public IHttpActionResult GetMovies()
        {
            var movies = Db.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
            //foreach(var m in movies)
            //{
            //    m.ReleaseDate = m.ReleaseDate.ToShortDateString();
            //}
            return Ok(movies);

        }
        public IHttpActionResult GetMovies(int id)
        {
            var movie = Db.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        [HttpPost]
        [Authorize(Roles = Role.canManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            Db.Movies.Add(movie);
            Db.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);

        }
        [HttpPut]
        [Authorize(Roles = Role.canManageMovies)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = Db.Movies.Single(m => m.Id == movieDto.Id);
            Mapper.Map(movieDto, movieInDb);
            Db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = Role.canManageMovies)]
        public IHttpActionResult DeleteMovie(int id)               
        {
            var movie = Db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            Db.Movies.Remove(movie);
            Db.SaveChanges();
            return Ok();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalService.Models;
using VideoRentalService.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace VideoRentalService.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Get list of all Movies
        // GET/api/Movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genre);

            if (!string.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query) && m.NumberAvailable != 0);


            var movieDtos = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);


        }

        // Get Movie by ID
        // GET/api/Movies/{id}
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            else
                return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        // Create a movie
        // POST api/Movies/
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Get current Date Time to register for Movie Added Date
            DateTime currTime = DateTime.Now;
            
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            
            movieDto.DateAdded = currTime;
            movie.DateAdded = currTime;


            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }


        // Update a Movie
        // PUT api/Movies
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + id), movieDto);
        }

        // Delete a Movie
        // DELETE api/Movies
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }



    }
}

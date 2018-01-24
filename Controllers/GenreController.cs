using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHistoryApi.Data;
using MusicHistoryApi.Models;

namespace MusicHistoryApi.Controllers
{
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public GenreController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var genres = _context.Genre.ToList();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingleGenre")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Genre genre = _context.Genre.Single(g => g.GenreId == id);

                if (genre == null)
                {
                    return NotFound();
                }

                return Ok(genre);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Genre.Add(genre);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GenreExists(genre.GenreId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleGenre", new { id = genre.GenreId }, genre);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.GenreId)
            {
                return BadRequest();
            }
            _context.Genre.Update(genre);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Genre genre = _context.Genre.Single(g => g.GenreId == id);

            if (genre == null)
            {
                return NotFound();
            }
            _context.Genre.Remove(genre);
            _context.SaveChanges();
            return Ok(genre);
        }

        private bool GenreExists(int genreId)
        {
            return _context.Genre.Any(g => g.GenreId == genreId);
        }
    }
}
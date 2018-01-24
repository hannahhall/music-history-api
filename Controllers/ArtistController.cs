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
    public class ArtistController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public ArtistController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var artists = _context.Artist.ToList();
            if (artists == null)
            {
                return NotFound();
            }
            return Ok(artists);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetSingleArtist")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Artist artist = _context.Artist.Single(g => g.ArtistId == id);

                if (artist == null)
                {
                    return NotFound();
                }

                return Ok(artist);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Artist.Add(artist);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ArtistExists(artist.ArtistId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleArtist", new { id = artist.ArtistId }, artist);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }
            _context.Artist.Update(artist);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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
            Artist artist = _context.Artist.Single(g => g.ArtistId == id);

            if (artist == null)
            {
                return NotFound();
            }
            _context.Artist.Remove(artist);
            _context.SaveChanges();
            return Ok(artist);
        }

        private bool ArtistExists(int artistId)
        {
            return _context.Artist.Any(g => g.ArtistId == artistId);
        }
        
    }
}
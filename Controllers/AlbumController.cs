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
    public class AlbumController : Controller
    {
        private ApplicationDbContext _context;
        // Constructor method to create an instance of context to communicate with our database.
        public AlbumController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var albums = _context.Album.ToList();
            if (albums == null)
            {
                return NotFound();
            }
            return Ok(albums);
        }

        // GET api/album/5
        [HttpGet("{id}", Name = "GetSingleAlbum")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Album album = _context.Album.Single(g => g.AlbumId == id);

                if (album == null)
                {
                    return NotFound();
                }

                return Ok(album);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Album.Add(album);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AlbumExists(album.AlbumId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetSingleAlbum", new { id = album.AlbumId }, album);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }
            _context.Album.Update(album);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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
            Album album = _context.Album.Single(g => g.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }
            _context.Album.Remove(album);
            _context.SaveChanges();
            return Ok(album);
        }

        private bool AlbumExists(int albumId)
        {
            return _context.Album.Any(g => g.AlbumId == albumId);
        }

    }
}
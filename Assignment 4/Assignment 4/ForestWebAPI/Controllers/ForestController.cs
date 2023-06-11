using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForestLibrary;
using ForestLibrary.Models;

namespace ForestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForestController : ControllerBase
    {
        private readonly ForestContext _context;

        public ForestController(ForestContext context)
        {
            _context = context;
        }

        // GET: api/Forest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forest>>> GetForests()
        {
          if (_context.Forests == null) { return NotFound(); }
          return await _context.Forests.ToListAsync();
        }

        // GET: api/Forest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forest>> GetForest(int id)
        {
          if (_context.Forests == null) { return NotFound(); }
          var forest = await _context.Forests.FindAsync(id);
          if (forest == null) { return NotFound(); }
          return forest;
        }

        // PUT: api/Forest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForest(int id, Forest forest)
        {
            if (id != forest.ForestId) { return BadRequest(); }

            _context.Entry(forest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Forest
        [HttpPost]
        public async Task<ActionResult<Forest>> PostForest(Forest forest)
        {
          if (_context.Forests == null)
          {
              return Problem("Entity set 'ForestContext.Forests'  is null.");
          }
          _context.Forests.Add(forest);
          await _context.SaveChangesAsync();
          return CreatedAtAction("GetForest", new { id = forest.ForestId }, forest);
        }

        // DELETE: api/Forest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForest(int id)
        {
            if (_context.Forests == null) { return NotFound(); }
            var forest = await _context.Forests.FindAsync(id);
            if (forest == null) { return NotFound(); }

            _context.Forests.Remove(forest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForestExists(int id)
        {
            return (_context.Forests?.Any(e => e.ForestId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_2.Data;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ForestContext _context;

        public TreeController(ForestContext context)
        {
            _context = context;
        }

        // GET: api/Tree
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tree>>> GetTrees()
        {
          if (_context.Trees == null)
          {
              return NotFound();
          }
            return await _context.Trees.ToListAsync();
        }

        // GET: api/Tree/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tree>> GetTree(int id)
        {
          if (_context.Trees == null)
          {
              return NotFound();
          }
            var tree = await _context.Trees.FindAsync(id);

            if (tree == null)
            {
                return NotFound();
            }

            return tree;
        }

        // PUT: api/Tree/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTree(int id, Tree tree)
        {
            if (id != tree.TreeId)
            {
                return BadRequest();
            }

            _context.Entry(tree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeExists(id))
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

        // POST: api/Tree
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tree>> PostTree(Tree tree)
        {
          if (_context.Trees == null)
          {
              return Problem("Entity set 'ForestContext.Trees'  is null.");
          }
            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTree", new { id = tree.TreeId }, tree);
        }

        // DELETE: api/Tree/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTree(int id)
        {
            if (_context.Trees == null)
            {
                return NotFound();
            }
            var tree = await _context.Trees.FindAsync(id);
            if (tree == null)
            {
                return NotFound();
            }

            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreeExists(int id)
        {
            return (_context.Trees?.Any(e => e.TreeId == id)).GetValueOrDefault();
        }
    }
}

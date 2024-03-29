using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForestLibrary;
using ForestLibrary.Models;

namespace ForestMVC
{
    public class TreesController : Controller
    {
        private readonly ForestContext _context;

        public TreesController(ForestContext context)
        {
            _context = context;
        }

        // GET: Trees
        public async Task<IActionResult> Index()
        {
              return _context.Trees != null ? 
                          View(await _context.Trees.ToListAsync()) :
                          Problem("Entity set 'ForestContext.Trees'  is null.");
        }

        // GET: Trees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var tree = await _context.Trees
                .FirstOrDefaultAsync(m => m.TreeId == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // GET: Trees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreeId,Name,Species,Height")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tree);
        }

        // GET: Trees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var tree = await _context.Trees.FindAsync(id);
            if (tree == null)
            {
                return NotFound();
            }
            return View(tree);
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreeId,Name,Species,Height")] Tree tree)
        {
            if (id != tree.TreeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreeExists(tree.TreeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tree);
        }

        // GET: Trees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trees == null)
            {
                return NotFound();
            }

            var tree = await _context.Trees
                .FirstOrDefaultAsync(m => m.TreeId == id);
            if (tree == null)
            {
                return NotFound();
            }

            return View(tree);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trees == null)
            {
                return Problem("Entity set 'ForestContext.Trees'  is null.");
            }
            var tree = await _context.Trees.FindAsync(id);
            if (tree != null)
            {
                _context.Trees.Remove(tree);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreeExists(int id)
        {
          return (_context.Trees?.Any(e => e.TreeId == id)).GetValueOrDefault();
        }
    }
}

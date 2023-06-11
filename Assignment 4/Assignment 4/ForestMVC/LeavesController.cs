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
    public class LeavesController : Controller
    {
        private readonly ForestContext _context;

        public LeavesController(ForestContext context)
        {
            _context = context;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            var forestContext = _context.Leaves.Include(l => l.Branch);
            return View(await forestContext.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leaves == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .Include(l => l.Branch)
                .FirstOrDefaultAsync(m => m.LeafId == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // GET: Leaves/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeafId,Name,BranchId")] Leaf leaf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", leaf.BranchId);
            return View(leaf);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leaves == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves.FindAsync(id);
            if (leaf == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", leaf.BranchId);
            return View(leaf);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeafId,Name,BranchId")] Leaf leaf)
        {
            if (id != leaf.LeafId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeafExists(leaf.LeafId))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchId", leaf.BranchId);
            return View(leaf);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leaves == null)
            {
                return NotFound();
            }

            var leaf = await _context.Leaves
                .Include(l => l.Branch)
                .FirstOrDefaultAsync(m => m.LeafId == id);
            if (leaf == null)
            {
                return NotFound();
            }

            return View(leaf);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leaves == null)
            {
                return Problem("Entity set 'ForestContext.Leaves'  is null.");
            }
            var leaf = await _context.Leaves.FindAsync(id);
            if (leaf != null)
            {
                _context.Leaves.Remove(leaf);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeafExists(int id)
        {
          return (_context.Leaves?.Any(e => e.LeafId == id)).GetValueOrDefault();
        }
    }
}

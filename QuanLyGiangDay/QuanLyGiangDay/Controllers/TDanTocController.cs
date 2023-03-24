using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyGiangDay.Models;

namespace QuanLyGiangDay.Controllers
{
    public class TDanTocController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TDanTocController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TDanToc
        public async Task<IActionResult> Index()
        {
              return _context.TDanTocs != null ? 
                          View(await _context.TDanTocs.ToListAsync()) :
                          Problem("Entity set 'QuanLyGiangDayContext.TDanTocs'  is null.");
        }

        // GET: TDanToc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TDanTocs == null)
            {
                return NotFound();
            }

            var tDanToc = await _context.TDanTocs
                .FirstOrDefaultAsync(m => m.MaDanToc == id);
            if (tDanToc == null)
            {
                return NotFound();
            }

            return View(tDanToc);
        }

        // GET: TDanToc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TDanToc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDanToc,TenDanToc")] TDanToc tDanToc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tDanToc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tDanToc);
        }

        // GET: TDanToc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TDanTocs == null)
            {
                return NotFound();
            }

            var tDanToc = await _context.TDanTocs.FindAsync(id);
            if (tDanToc == null)
            {
                return NotFound();
            }
            return View(tDanToc);
        }

        // POST: TDanToc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDanToc,TenDanToc")] TDanToc tDanToc)
        {
            if (id != tDanToc.MaDanToc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tDanToc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TDanTocExists(tDanToc.MaDanToc))
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
            return View(tDanToc);
        }

        // GET: TDanToc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TDanTocs == null)
            {
                return NotFound();
            }

            var tDanToc = await _context.TDanTocs
                .FirstOrDefaultAsync(m => m.MaDanToc == id);
            if (tDanToc == null)
            {
                return NotFound();
            }

            return View(tDanToc);
        }

        // POST: TDanToc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TDanTocs == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TDanTocs'  is null.");
            }
            var tDanToc = await _context.TDanTocs.FindAsync(id);
            if (tDanToc != null)
            {
                _context.TDanTocs.Remove(tDanToc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TDanTocExists(int id)
        {
          return (_context.TDanTocs?.Any(e => e.MaDanToc == id)).GetValueOrDefault();
        }
    }
}

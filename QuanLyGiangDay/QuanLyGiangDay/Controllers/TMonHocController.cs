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
    public class TMonHocController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TMonHocController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TMonHoc
        public async Task<IActionResult> Index()
        {
              return _context.TMonHocs != null ? 
                          View(await _context.TMonHocs.ToListAsync()) :
                          Problem("Entity set 'QuanLyGiangDayContext.TMonHocs'  is null.");
        }

        // GET: TMonHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TMonHocs == null)
            {
                return NotFound();
            }

            var tMonHoc = await _context.TMonHocs
                .FirstOrDefaultAsync(m => m.MaMonHoc == id);
            if (tMonHoc == null)
            {
                return NotFound();
            }

            return View(tMonHoc);
        }

        // GET: TMonHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TMonHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMonHoc,TenMonHoc,SoTietLyThuyet,SoTietThucHanh")] TMonHoc tMonHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tMonHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tMonHoc);
        }

        // GET: TMonHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TMonHocs == null)
            {
                return NotFound();
            }

            var tMonHoc = await _context.TMonHocs.FindAsync(id);
            if (tMonHoc == null)
            {
                return NotFound();
            }
            return View(tMonHoc);
        }

        // POST: TMonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaMonHoc,TenMonHoc,SoTietLyThuyet,SoTietThucHanh")] TMonHoc tMonHoc)
        {
            if (id != tMonHoc.MaMonHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tMonHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TMonHocExists(tMonHoc.MaMonHoc))
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
            return View(tMonHoc);
        }

        // GET: TMonHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TMonHocs == null)
            {
                return NotFound();
            }

            var tMonHoc = await _context.TMonHocs
                .FirstOrDefaultAsync(m => m.MaMonHoc == id);
            if (tMonHoc == null)
            {
                return NotFound();
            }

            return View(tMonHoc);
        }

        // POST: TMonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TMonHocs == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TMonHocs'  is null.");
            }
            var tMonHoc = await _context.TMonHocs.FindAsync(id);
            if (tMonHoc != null)
            {
                _context.TMonHocs.Remove(tMonHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMonHocExists(int id)
        {
          return (_context.TMonHocs?.Any(e => e.MaMonHoc == id)).GetValueOrDefault();
        }
    }
}

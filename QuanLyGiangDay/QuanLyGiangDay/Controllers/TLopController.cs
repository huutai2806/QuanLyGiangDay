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
    public class TLopController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TLopController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TLop
        public IActionResult Index(string searchString)
        {
            var lop = from l in _context.TLops
                      select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                lop = lop.Where(s => s.MaLop.ToString().Contains(searchString)
                                     || s.TenLop.Contains(searchString)
                                     || s.MaNganhHoc.ToString().Contains(searchString)
                                     || s.MaGvcn.ToString().Contains(searchString));
            }

            return View(lop);
        }
        // GET: TLop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TLops == null)
            {
                return NotFound();
            }

            var tLop = await _context.TLops
                .Include(t => t.MaGvcnNavigation)
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (tLop == null)
            {
                return NotFound();
            }

            return View(tLop);
        }

        // GET: TLop/Create
        public IActionResult Create()
        {
            ViewData["MaGvcn"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien");
            return View();
        }

        // POST: TLop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLop,TenLop,MaNganhHoc,MaGvcn")] TLop tLop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tLop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGvcn"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tLop.MaGvcn);
            return View(tLop);
        }

        // GET: TLop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TLops == null)
            {
                return NotFound();
            }

            var tLop = await _context.TLops.FindAsync(id);
            if (tLop == null)
            {
                return NotFound();
            }
            ViewData["MaGvcn"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tLop.MaGvcn);
            return View(tLop);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLop,TenLop,MaNganhHoc,MaGvcn")] TLop tLop)
        {
            if (id != tLop.MaLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tLop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TLopExists(tLop.MaLop))
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
            ViewData["MaGvcn"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tLop.MaGvcn);
            return View(tLop);
        }

        // GET: TLop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TLops == null)
            {
                return NotFound();
            }

            var tLop = await _context.TLops
                .Include(t => t.MaGvcnNavigation)
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (tLop == null)
            {
                return NotFound();
            }

            return View(tLop);
        }

        // POST: TLop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TLops == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TLops'  is null.");
            }
            var tLop = await _context.TLops.FindAsync(id);
            if (tLop != null)
            {
                _context.TLops.Remove(tLop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TLopExists(int id)
        {
          return (_context.TLops?.Any(e => e.MaLop == id)).GetValueOrDefault();
        }
    }
}

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
    public class TKetQuaController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TKetQuaController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TKetQua
        public async Task<IActionResult> Index()
        {
            var quanLyGiangDayContext = _context.TKetQuas.Include(t => t.MaPhanCongNavigation).Include(t => t.MaSinhVienNavigation);
            return View(await quanLyGiangDayContext.ToListAsync());
        }

        // GET: TKetQua/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TKetQuas == null)
            {
                return NotFound();
            }

            var tKetQua = await _context.TKetQuas
                .Include(t => t.MaPhanCongNavigation)
                .Include(t => t.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            if (tKetQua == null)
            {
                return NotFound();
            }

            return View(tKetQua);
        }

        // GET: TKetQua/Create
        public IActionResult Create()
        {
            ViewData["MaPhanCong"] = new SelectList(_context.TPhanCongs, "MaPhanCong", "MaPhanCong");
            ViewData["MaSinhVien"] = new SelectList(_context.TSinhViens, "MaSinhVien", "MaSinhVien");
            return View();
        }

        // POST: TKetQua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanCong,MaSinhVien,LanThi,Diem,GhiChu")] TKetQua tKetQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tKetQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaPhanCong"] = new SelectList(_context.TPhanCongs, "MaPhanCong", "MaPhanCong", tKetQua.MaPhanCong);
            ViewData["MaSinhVien"] = new SelectList(_context.TSinhViens, "MaSinhVien", "MaSinhVien", tKetQua.MaSinhVien);
            return View(tKetQua);
        }

        // GET: TKetQua/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TKetQuas == null)
            {
                return NotFound();
            }

            var tKetQua = await _context.TKetQuas.FindAsync(id);
            if (tKetQua == null)
            {
                return NotFound();
            }
            ViewData["MaPhanCong"] = new SelectList(_context.TPhanCongs, "MaPhanCong", "MaPhanCong", tKetQua.MaPhanCong);
            ViewData["MaSinhVien"] = new SelectList(_context.TSinhViens, "MaSinhVien", "MaSinhVien", tKetQua.MaSinhVien);
            return View(tKetQua);
        }

        // POST: TKetQua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhanCong,MaSinhVien,LanThi,Diem,GhiChu")] TKetQua tKetQua)
        {
            if (id != tKetQua.MaPhanCong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tKetQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TKetQuaExists(tKetQua.MaPhanCong))
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
            ViewData["MaPhanCong"] = new SelectList(_context.TPhanCongs, "MaPhanCong", "MaPhanCong", tKetQua.MaPhanCong);
            ViewData["MaSinhVien"] = new SelectList(_context.TSinhViens, "MaSinhVien", "MaSinhVien", tKetQua.MaSinhVien);
            return View(tKetQua);
        }

        // GET: TKetQua/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TKetQuas == null)
            {
                return NotFound();
            }

            var tKetQua = await _context.TKetQuas
                .Include(t => t.MaPhanCongNavigation)
                .Include(t => t.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            if (tKetQua == null)
            {
                return NotFound();
            }

            return View(tKetQua);
        }

        // POST: TKetQua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TKetQuas == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TKetQuas'  is null.");
            }
            var tKetQua = await _context.TKetQuas.FindAsync(id);
            if (tKetQua != null)
            {
                _context.TKetQuas.Remove(tKetQua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TKetQuaExists(int id)
        {
          return (_context.TKetQuas?.Any(e => e.MaPhanCong == id)).GetValueOrDefault();
        }
    }
}

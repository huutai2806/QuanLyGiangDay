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
    public class TPhanCongController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TPhanCongController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TPhanCong
        public async Task<IActionResult> Index()
        {
            var quanLyGiangDayContext = _context.TPhanCongs.Include(t => t.MaGiaoVienNavigation).Include(t => t.MaLopNavigation).Include(t => t.MaMonHocNavigation);
            return View(await quanLyGiangDayContext.ToListAsync());
        }

        // GET: TPhanCong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TPhanCongs == null)
            {
                return NotFound();
            }

            var tPhanCong = await _context.TPhanCongs
                .Include(t => t.MaGiaoVienNavigation)
                .Include(t => t.MaLopNavigation)
                .Include(t => t.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            if (tPhanCong == null)
            {
                return NotFound();
            }

            return View(tPhanCong);
        }

        // GET: TPhanCong/Create
        public IActionResult Create()
        {
            ViewData["MaGiaoVien"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien");
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop");
            ViewData["MaMonHoc"] = new SelectList(_context.TMonHocs, "MaMonHoc", "MaMonHoc");
            return View();
        }

        // POST: TPhanCong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhanCong,MaMonHoc,MaGiaoVien,MaLop,HocKy,Năm,NgayBatDau,NgayKetThuc")] TPhanCong tPhanCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tPhanCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGiaoVien"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tPhanCong.MaGiaoVien);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tPhanCong.MaLop);
            ViewData["MaMonHoc"] = new SelectList(_context.TMonHocs, "MaMonHoc", "MaMonHoc", tPhanCong.MaMonHoc);
            return View(tPhanCong);
        }

        // GET: TPhanCong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TPhanCongs == null)
            {
                return NotFound();
            }

            var tPhanCong = await _context.TPhanCongs.FindAsync(id);
            if (tPhanCong == null)
            {
                return NotFound();
            }
            ViewData["MaGiaoVien"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tPhanCong.MaGiaoVien);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tPhanCong.MaLop);
            ViewData["MaMonHoc"] = new SelectList(_context.TMonHocs, "MaMonHoc", "MaMonHoc", tPhanCong.MaMonHoc);
            return View(tPhanCong);
        }

        // POST: TPhanCong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhanCong,MaMonHoc,MaGiaoVien,MaLop,HocKy,Năm,NgayBatDau,NgayKetThuc")] TPhanCong tPhanCong)
        {
            if (id != tPhanCong.MaPhanCong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPhanCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPhanCongExists(tPhanCong.MaPhanCong))
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
            ViewData["MaGiaoVien"] = new SelectList(_context.TGiaoViens, "MaGiaoVien", "MaGiaoVien", tPhanCong.MaGiaoVien);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tPhanCong.MaLop);
            ViewData["MaMonHoc"] = new SelectList(_context.TMonHocs, "MaMonHoc", "MaMonHoc", tPhanCong.MaMonHoc);
            return View(tPhanCong);
        }

        // GET: TPhanCong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TPhanCongs == null)
            {
                return NotFound();
            }

            var tPhanCong = await _context.TPhanCongs
                .Include(t => t.MaGiaoVienNavigation)
                .Include(t => t.MaLopNavigation)
                .Include(t => t.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaPhanCong == id);
            if (tPhanCong == null)
            {
                return NotFound();
            }

            return View(tPhanCong);
        }

        // POST: TPhanCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TPhanCongs == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TPhanCongs'  is null.");
            }
            var tPhanCong = await _context.TPhanCongs.FindAsync(id);
            if (tPhanCong != null)
            {
                _context.TPhanCongs.Remove(tPhanCong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPhanCongExists(int id)
        {
          return (_context.TPhanCongs?.Any(e => e.MaPhanCong == id)).GetValueOrDefault();
        }
    }
}

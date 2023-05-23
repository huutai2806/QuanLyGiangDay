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
    public class TSinhVienController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TSinhVienController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TSinhVien
        public async Task<IActionResult> Index(string searchString)
        {
            var sinhViens = from s in _context.TSinhViens
                            select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                sinhViens = sinhViens.Where(s => s.MaSinhVien.ToString().Contains(searchString)
                                                || s.HoSinhVien.Contains(searchString)
                                                || s.TenSinhVien.Contains(searchString)
                                                || s.MaLopNavigation.TenLop.Contains(searchString)
                                                || s.PhaiNu.Contains(searchString)
                                                || s.DiaChi.Contains(searchString)
                                                || s.MaQueQuanNavigation.TenTinhThanhPho.Contains(searchString)
                                                || s.MaQueQuanNavigation.TenQuanHuyen.Contains(searchString)
                                                || s.MaQueQuanNavigation.TenPhuongXa.Contains(searchString)
                                                || s.MaDanTocNavigation.TenDanToc.Contains(searchString)
                                                || s.MaTonGiaoNavigation.TenTonGiao.Contains(searchString));
            }

            return View(await sinhViens.AsNoTracking().ToListAsync());
        }

        // GET: TSinhVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TSinhViens == null)
            {
                return NotFound();
            }

            var tSinhVien = await _context.TSinhViens
                .Include(t => t.MaDanTocNavigation)
                .Include(t => t.MaLopNavigation)
                .Include(t => t.MaQueQuanNavigation)
                .Include(t => t.MaTonGiaoNavigation)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (tSinhVien == null)
            {
                return NotFound();
            }

            return View(tSinhVien);
        }

        // GET: TSinhVien/Create
        public IActionResult Create()
        {
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc");
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop");
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan");
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,HoSinhVien,TenSinhVien,MaLop,PhaiNu,NgaySinh,DiaChi,MaQueQuan,Hinh,MaDanToc,MaTonGiao")] TSinhVien tSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tSinhVien.MaDanToc);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tSinhVien.MaLop);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tSinhVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tSinhVien.MaTonGiao);
            return View(tSinhVien);
        }

        // GET: TSinhVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TSinhViens == null)
            {
                return NotFound();
            }

            var tSinhVien = await _context.TSinhViens.FindAsync(id);
            if (tSinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tSinhVien.MaDanToc);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tSinhVien.MaLop);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tSinhVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tSinhVien.MaTonGiao);
            return View(tSinhVien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSinhVien,HoSinhVien,TenSinhVien,MaLop,PhaiNu,NgaySinh,DiaChi,MaQueQuan,Hinh,MaDanToc,MaTonGiao")] TSinhVien tSinhVien)
        {
            if (id != tSinhVien.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSinhVienExists(tSinhVien.MaSinhVien))
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
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tSinhVien.MaDanToc);
            ViewData["MaLop"] = new SelectList(_context.TLops, "MaLop", "MaLop", tSinhVien.MaLop);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tSinhVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tSinhVien.MaTonGiao);
            return View(tSinhVien);
        }

        // GET: TSinhVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TSinhViens == null)
            {
                return NotFound();
            }

            var tSinhVien = await _context.TSinhViens
                .Include(t => t.MaDanTocNavigation)
                .Include(t => t.MaLopNavigation)
                .Include(t => t.MaQueQuanNavigation)
                .Include(t => t.MaTonGiaoNavigation)
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (tSinhVien == null)
            {
                return NotFound();
            }

            return View(tSinhVien);
        }

        // POST: TSinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TSinhViens == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TSinhViens'  is null.");
            }
            var tSinhVien = await _context.TSinhViens.FindAsync(id);
            if (tSinhVien != null)
            {
                _context.TSinhViens.Remove(tSinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TSinhVienExists(int id)
        {
          return (_context.TSinhViens?.Any(e => e.MaSinhVien == id)).GetValueOrDefault();
        }
    }
}

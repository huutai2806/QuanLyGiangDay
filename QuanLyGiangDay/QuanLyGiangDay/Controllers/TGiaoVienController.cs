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
    public class TGiaoVienController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TGiaoVienController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TGiaoVien
        public async Task<IActionResult> Index()
        {
            var quanLyGiangDayContext = _context.TGiaoViens.Include(t => t.MaDanTocNavigation).Include(t => t.MaQueQuanNavigation).Include(t => t.MaTonGiaoNavigation);
            return View(await quanLyGiangDayContext.ToListAsync());
        }

        // GET: TGiaoVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TGiaoViens == null)
            {
                return NotFound();
            }

            var tGiaoVien = await _context.TGiaoViens
                .Include(t => t.MaDanTocNavigation)
                .Include(t => t.MaQueQuanNavigation)
                .Include(t => t.MaTonGiaoNavigation)
                .FirstOrDefaultAsync(m => m.MaGiaoVien == id);
            if (tGiaoVien == null)
            {
                return NotFound();
            }

            return View(tGiaoVien);
        }

        // GET: TGiaoVien/Create
        public IActionResult Create()
        {
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc");
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan");
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao");
            return View();
        }

        // POST: TGiaoVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiaoVien,TenGiaoVien,PhaiNu,SoDienThoai,DiaChi,Email,MaQueQuan,MaDanToc,MaTonGiao")] TGiaoVien tGiaoVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tGiaoVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tGiaoVien.MaDanToc);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tGiaoVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tGiaoVien.MaTonGiao);
            return View(tGiaoVien);
        }

        // GET: TGiaoVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TGiaoViens == null)
            {
                return NotFound();
            }

            var tGiaoVien = await _context.TGiaoViens.FindAsync(id);
            if (tGiaoVien == null)
            {
                return NotFound();
            }
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tGiaoVien.MaDanToc);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tGiaoVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tGiaoVien.MaTonGiao);
            return View(tGiaoVien);
        }

        // POST: TGiaoVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGiaoVien,TenGiaoVien,PhaiNu,SoDienThoai,DiaChi,Email,MaQueQuan,MaDanToc,MaTonGiao")] TGiaoVien tGiaoVien)
        {
            if (id != tGiaoVien.MaGiaoVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tGiaoVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TGiaoVienExists(tGiaoVien.MaGiaoVien))
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
            ViewData["MaDanToc"] = new SelectList(_context.TDanTocs, "MaDanToc", "MaDanToc", tGiaoVien.MaDanToc);
            ViewData["MaQueQuan"] = new SelectList(_context.TQueQuans, "MaQueQuan", "MaQueQuan", tGiaoVien.MaQueQuan);
            ViewData["MaTonGiao"] = new SelectList(_context.TTonGiaos, "MaTonGiao", "MaTonGiao", tGiaoVien.MaTonGiao);
            return View(tGiaoVien);
        }

        // GET: TGiaoVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TGiaoViens == null)
            {
                return NotFound();
            }

            var tGiaoVien = await _context.TGiaoViens
                .Include(t => t.MaDanTocNavigation)
                .Include(t => t.MaQueQuanNavigation)
                .Include(t => t.MaTonGiaoNavigation)
                .FirstOrDefaultAsync(m => m.MaGiaoVien == id);
            if (tGiaoVien == null)
            {
                return NotFound();
            }

            return View(tGiaoVien);
        }

        // POST: TGiaoVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TGiaoViens == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TGiaoViens'  is null.");
            }
            var tGiaoVien = await _context.TGiaoViens.FindAsync(id);
            if (tGiaoVien != null)
            {
                _context.TGiaoViens.Remove(tGiaoVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TGiaoVienExists(int id)
        {
          return (_context.TGiaoViens?.Any(e => e.MaGiaoVien == id)).GetValueOrDefault();
        }
    }
}

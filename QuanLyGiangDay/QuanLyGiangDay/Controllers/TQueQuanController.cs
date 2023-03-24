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
    public class TQueQuanController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TQueQuanController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TQueQuan
        public async Task<IActionResult> Index()
        {
              return _context.TQueQuans != null ? 
                          View(await _context.TQueQuans.ToListAsync()) :
                          Problem("Entity set 'QuanLyGiangDayContext.TQueQuans'  is null.");
        }

        // GET: TQueQuan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TQueQuans == null)
            {
                return NotFound();
            }

            var tQueQuan = await _context.TQueQuans
                .FirstOrDefaultAsync(m => m.MaQueQuan == id);
            if (tQueQuan == null)
            {
                return NotFound();
            }

            return View(tQueQuan);
        }

        // GET: TQueQuan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TQueQuan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQueQuan,TenTinhThanhPho,TenQuanHuyen,TenPhuongXa")] TQueQuan tQueQuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tQueQuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tQueQuan);
        }

        // GET: TQueQuan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TQueQuans == null)
            {
                return NotFound();
            }

            var tQueQuan = await _context.TQueQuans.FindAsync(id);
            if (tQueQuan == null)
            {
                return NotFound();
            }
            return View(tQueQuan);
        }

        // POST: TQueQuan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaQueQuan,TenTinhThanhPho,TenQuanHuyen,TenPhuongXa")] TQueQuan tQueQuan)
        {
            if (id != tQueQuan.MaQueQuan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tQueQuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TQueQuanExists(tQueQuan.MaQueQuan))
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
            return View(tQueQuan);
        }

        // GET: TQueQuan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TQueQuans == null)
            {
                return NotFound();
            }

            var tQueQuan = await _context.TQueQuans
                .FirstOrDefaultAsync(m => m.MaQueQuan == id);
            if (tQueQuan == null)
            {
                return NotFound();
            }

            return View(tQueQuan);
        }

        // POST: TQueQuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TQueQuans == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TQueQuans'  is null.");
            }
            var tQueQuan = await _context.TQueQuans.FindAsync(id);
            if (tQueQuan != null)
            {
                _context.TQueQuans.Remove(tQueQuan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TQueQuanExists(int id)
        {
          return (_context.TQueQuans?.Any(e => e.MaQueQuan == id)).GetValueOrDefault();
        }
    }
}

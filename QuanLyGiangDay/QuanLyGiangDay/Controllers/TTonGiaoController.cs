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
    public class TTonGiaoController : Controller
    {
        private readonly QuanLyGiangDayContext _context;

        public TTonGiaoController(QuanLyGiangDayContext context)
        {
            _context = context;
        }

        // GET: TTonGiao
        public async Task<IActionResult> Index()
        {
              return _context.TTonGiaos != null ? 
                          View(await _context.TTonGiaos.ToListAsync()) :
                          Problem("Entity set 'QuanLyGiangDayContext.TTonGiaos'  is null.");
        }

        // GET: TTonGiao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TTonGiaos == null)
            {
                return NotFound();
            }

            var tTonGiao = await _context.TTonGiaos
                .FirstOrDefaultAsync(m => m.MaTonGiao == id);
            if (tTonGiao == null)
            {
                return NotFound();
            }

            return View(tTonGiao);
        }

        // GET: TTonGiao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTonGiao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTonGiao,TenTonGiao")] TTonGiao tTonGiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tTonGiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tTonGiao);
        }

        // GET: TTonGiao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TTonGiaos == null)
            {
                return NotFound();
            }

            var tTonGiao = await _context.TTonGiaos.FindAsync(id);
            if (tTonGiao == null)
            {
                return NotFound();
            }
            return View(tTonGiao);
        }

        // POST: TTonGiao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTonGiao,TenTonGiao")] TTonGiao tTonGiao)
        {
            if (id != tTonGiao.MaTonGiao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTonGiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTonGiaoExists(tTonGiao.MaTonGiao))
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
            return View(tTonGiao);
        }

        // GET: TTonGiao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TTonGiaos == null)
            {
                return NotFound();
            }

            var tTonGiao = await _context.TTonGiaos
                .FirstOrDefaultAsync(m => m.MaTonGiao == id);
            if (tTonGiao == null)
            {
                return NotFound();
            }

            return View(tTonGiao);
        }

        // POST: TTonGiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TTonGiaos == null)
            {
                return Problem("Entity set 'QuanLyGiangDayContext.TTonGiaos'  is null.");
            }
            var tTonGiao = await _context.TTonGiaos.FindAsync(id);
            if (tTonGiao != null)
            {
                _context.TTonGiaos.Remove(tTonGiao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTonGiaoExists(int id)
        {
          return (_context.TTonGiaos?.Any(e => e.MaTonGiao == id)).GetValueOrDefault();
        }
    }
}

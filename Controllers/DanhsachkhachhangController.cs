using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nhom4.Data;
using nhom4.Models;

namespace nhom4.Controllers
{
    public class DanhsachkhachhangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhsachkhachhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Danhsachkhachhang
        public async Task<IActionResult> Index()
        {
              return _context.Danhsachkhachhang != null ? 
                          View(await _context.Danhsachkhachhang.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Danhsachkhachhang'  is null.");
        }

        // GET: Danhsachkhachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Danhsachkhachhang == null)
            {
                return NotFound();
            }

            var danhsachkhachhang = await _context.Danhsachkhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (danhsachkhachhang == null)
            {
                return NotFound();
            }

            return View(danhsachkhachhang);
        }

        // GET: Danhsachkhachhang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Danhsachkhachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Danhsachkhachhang danhsachkhachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhsachkhachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhsachkhachhang);
        }

        // GET: Danhsachkhachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Danhsachkhachhang == null)
            {
                return NotFound();
            }

            var danhsachkhachhang = await _context.Danhsachkhachhang.FindAsync(id);
            if (danhsachkhachhang == null)
            {
                return NotFound();
            }
            return View(danhsachkhachhang);
        }

        // POST: Danhsachkhachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] Danhsachkhachhang danhsachkhachhang)
        {
            if (id != danhsachkhachhang.Makhachhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhsachkhachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhsachkhachhangExists(danhsachkhachhang.Makhachhang))
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
            return View(danhsachkhachhang);
        }

        // GET: Danhsachkhachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Danhsachkhachhang == null)
            {
                return NotFound();
            }

            var danhsachkhachhang = await _context.Danhsachkhachhang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (danhsachkhachhang == null)
            {
                return NotFound();
            }

            return View(danhsachkhachhang);
        }

        // POST: Danhsachkhachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Danhsachkhachhang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Danhsachkhachhang'  is null.");
            }
            var danhsachkhachhang = await _context.Danhsachkhachhang.FindAsync(id);
            if (danhsachkhachhang != null)
            {
                _context.Danhsachkhachhang.Remove(danhsachkhachhang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhsachkhachhangExists(string id)
        {
          return (_context.Danhsachkhachhang?.Any(e => e.Makhachhang == id)).GetValueOrDefault();
        }
    }
}

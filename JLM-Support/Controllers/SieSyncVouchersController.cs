using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JLM_Support.Models.SieSync;
using Microsoft.Extensions.Logging;

namespace JLM_Support.Controllers
{
    public class SieSyncVouchersController : Controller
    {
        private readonly SieSyncContext _context;
        private readonly ILogger<SieSyncVouchersController> _logger;
        public SieSyncVouchersController(SieSyncContext context, ILogger<SieSyncVouchersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: SieSyncVouchers
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET SieSyncVouchers VIA JSON!");
            return Json(new { data = await _context.Vouchers.ToListAsync() });
        }


        // GET: SieSyncVouchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // GET: SieSyncVouchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SieSyncVouchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,FortnoxId,Company,Email,FileName,FileId,AccessToken,Voucher1,VoucherNumber")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voucher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voucher);
        }

        // GET: SieSyncVouchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }
            return View(voucher);
        }

        // POST: SieSyncVouchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Created,FortnoxId,Company,Email,FileName,FileId,AccessToken,Voucher1,VoucherNumber")] Voucher voucher)
        {
            if (id != voucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voucher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoucherExists(voucher.Id))
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
            return View(voucher);
        }

        // GET: SieSyncVouchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // POST: SieSyncVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voucher = await _context.Vouchers.FindAsync(id);
            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherExists(int id)
        {
            return _context.Vouchers.Any(e => e.Id == id);
        }
    }
}

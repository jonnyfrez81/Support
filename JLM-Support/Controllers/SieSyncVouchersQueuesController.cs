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
    public class SieSyncVouchersQueuesController : Controller
    {
        private readonly SieSyncContext _context;
        private readonly ILogger<SieSyncVouchersQueuesController> _logger;

        public SieSyncVouchersQueuesController(SieSyncContext context, ILogger<SieSyncVouchersQueuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: SieSyncVouchersQueues
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET SieSyncVouchersQueues VIA JSON!");
            return Json(new { data = await _context.VouchersQueues.ToListAsync() });
        }

        // GET: SieSyncVouchersQueues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vouchersQueue = await _context.VouchersQueues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vouchersQueue == null)
            {
                return NotFound();
            }

            return View(vouchersQueue);
        }

        // GET: SieSyncVouchersQueues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SieSyncVouchersQueues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,FortnoxId,Company,Email,FileName,FileId,AccessToken,Voucher,Fail,FailMessage")] VouchersQueue vouchersQueue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vouchersQueue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vouchersQueue);
        }

        // GET: SieSyncVouchersQueues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vouchersQueue = await _context.VouchersQueues.FindAsync(id);
            if (vouchersQueue == null)
            {
                return NotFound();
            }
            return View(vouchersQueue);
        }

        // POST: SieSyncVouchersQueues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Created,FortnoxId,Company,Email,FileName,FileId,AccessToken,Voucher,Fail,FailMessage")] VouchersQueue vouchersQueue)
        {
            if (id != vouchersQueue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vouchersQueue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VouchersQueueExists(vouchersQueue.Id))
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
            return View(vouchersQueue);
        }

        // GET: SieSyncVouchersQueues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vouchersQueue = await _context.VouchersQueues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vouchersQueue == null)
            {
                return NotFound();
            }

            return View(vouchersQueue);
        }

        // POST: SieSyncVouchersQueues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vouchersQueue = await _context.VouchersQueues.FindAsync(id);
            _context.VouchersQueues.Remove(vouchersQueue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VouchersQueueExists(int id)
        {
            return _context.VouchersQueues.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JLM_Support.Models.PwcIca;
using Microsoft.Extensions.Logging;

namespace JLM_Support.Controllers
{
    public class PwcIcaTblSettingsController : Controller
    {
        private readonly pwc_icaContext _context;
        private readonly ILogger<PwcIcaTblSettingsController> _logger;
        public PwcIcaTblSettingsController(pwc_icaContext context, ILogger<PwcIcaTblSettingsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Pwc Ica stores
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET Pwc Ica stores VIA JSON!");
            return Json(new { data = await _context.TblSettings.ToListAsync() });
        }

        // GET: PwcIcaTblSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSetting = await _context.TblSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSetting == null)
            {
                return NotFound();
            }

            return View(tblSetting);
        }

        // GET: PwcIcaTblSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PwcIcaTblSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatabaseId,AuthorizationCode,Accesstoken,Companyname,Moms25,Moms12,Moms6,Moms0,Active,Voucherseries")] TblSetting tblSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSetting);
        }

        // GET: PwcIcaTblSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSetting = await _context.TblSettings.FindAsync(id);
            if (tblSetting == null)
            {
                return NotFound();
            }
            return View(tblSetting);
        }

        // POST: PwcIcaTblSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatabaseId,AuthorizationCode,Accesstoken,Companyname,Moms25,Moms12,Moms6,Moms0,Active,Voucherseries")] TblSetting tblSetting)
        {
            if (id != tblSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSettingExists(tblSetting.Id))
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
            return View(tblSetting);
        }

        // GET: PwcIcaTblSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSetting = await _context.TblSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSetting == null)
            {
                return NotFound();
            }

            return View(tblSetting);
        }

        // POST: PwcIcaTblSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSetting = await _context.TblSettings.FindAsync(id);
            _context.TblSettings.Remove(tblSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSettingExists(int id)
        {
            return _context.TblSettings.Any(e => e.Id == id);
        }
    }
}

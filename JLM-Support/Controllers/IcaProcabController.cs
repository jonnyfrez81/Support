using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JLM_Support.Models.IcaProcab;
using Microsoft.Extensions.Logging;

namespace JLM_Support.Controllers
{
    public class IcaProcabController : Controller
    {
        private readonly IcaProcabContext _context;
        private readonly ILogger<IcaProcabController> _logger;
        public IcaProcabController(IcaProcabContext context, ILogger<IcaProcabController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: IcaProcab
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET Ica Prokabs stores VIA JSON!");
            return Json(new { data = await _context.TblSettings.ToListAsync() });
        }

        // GET: IcaProcab/Details/5
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

        // GET: IcaProcab/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IcaProcab/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatabaseId,AuthorizationCode,Accesstoken,Companyname,Moms25,Moms12,Moms6,Moms0,Active,Voucherseries,OreAdjAcc,MomsXml25,MomsXml12,MomsXml6,MomsXml0")] TblSetting tblSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSetting);
        }

        // GET: IcaProcab/Edit/5
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

        // POST: IcaProcab/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatabaseId,AuthorizationCode,Accesstoken,Companyname,Moms25,Moms12,Moms6,Moms0,Active,Voucherseries,OreAdjAcc,MomsXml25,MomsXml12,MomsXml6,MomsXml0")] TblSetting tblSetting)
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

        // GET: IcaProcab/Delete/5
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

        // POST: IcaProcab/Delete/5
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

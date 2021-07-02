using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JLM_Support.Models.Klarna;
using Microsoft.Extensions.Logging;

namespace JLM_Support.Controllers
{
    public class KlarnaPaymentsController : Controller
    {
        private readonly KlarnaV3Context _context;
        private readonly ILogger<KlarnaPaymentsController> _logger;
        public KlarnaPaymentsController(KlarnaV3Context context, ILogger<KlarnaPaymentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Payments
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET PAYMENTS VIA JSON!");
            return Json(new { data = await _context.Payments.ToListAsync() });
        }


        // GET: KlarnaPayments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: KlarnaPayments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: KlarnaPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Reference,IncludeFee,ExcludeFee,Fee,Currency,IsBooked,BookingDate,CreatedDate,UserId,CapturedAt,OrderId,FortnoxInvoiceNumber,FortnoxPaymentNumber,FortNoxPaymentVoucherSeries,FortNoxPaymentVoucherNumber,Errors,PaymentReference,PurchaseCountry,VatAmountOnFee,VatAmountOnFeeCurrency,CaptureId,MerchantReference1,MerchantReference2,ShortOrderId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.Id = Guid.NewGuid();
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", payment.UserId);
            return View(payment);
        }

        // GET: KlarnaPayments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", payment.UserId);
            return View(payment);
        }

        // POST: KlarnaPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Reference,IncludeFee,ExcludeFee,Fee,Currency,IsBooked,BookingDate,CreatedDate,UserId,CapturedAt,OrderId,FortnoxInvoiceNumber,FortnoxPaymentNumber,FortNoxPaymentVoucherSeries,FortNoxPaymentVoucherNumber,Errors,PaymentReference,PurchaseCountry,VatAmountOnFee,VatAmountOnFeeCurrency,CaptureId,MerchantReference1,MerchantReference2,ShortOrderId")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", payment.UserId);
            return View(payment);
        }

        // GET: KlarnaPayments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: KlarnaPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(Guid id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}

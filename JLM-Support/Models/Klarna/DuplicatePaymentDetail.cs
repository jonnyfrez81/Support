using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class DuplicatePaymentDetail
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public decimal IncludeFee { get; set; }
        public decimal ExcludeFee { get; set; }
        public decimal Fee { get; set; }
        public string Currency { get; set; }
        public bool IsBooked { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime CapturedAt { get; set; }
        public string OrderId { get; set; }
        public string FortnoxInvoiceNumber { get; set; }
        public string FortnoxPaymentNumber { get; set; }
        public string FortNoxPaymentVoucherSeries { get; set; }
        public string FortNoxPaymentVoucherNumber { get; set; }
        public string Errors { get; set; }
        public string PaymentReference { get; set; }
        public string PurchaseCountry { get; set; }
        public decimal? VatAmountOnFee { get; set; }
        public string VatAmountOnFeeCurrency { get; set; }
        public string CaptureId { get; set; }
        public string MerchantReference1 { get; set; }
        public string MerchantReference2 { get; set; }
        public string ShortOrderId { get; set; }
    }
}

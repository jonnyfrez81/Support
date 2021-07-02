using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class PaymentCorrection
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
    }
}

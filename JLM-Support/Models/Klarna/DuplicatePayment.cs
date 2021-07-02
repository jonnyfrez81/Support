using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class DuplicatePayment
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string OrderId { get; set; }
        public int? TotalCount { get; set; }
    }
}

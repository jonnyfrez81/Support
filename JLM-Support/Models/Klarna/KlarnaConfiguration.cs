using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class KlarnaConfiguration
    {
        public Guid Id { get; set; }
        public string MerchantId { get; set; }
        public string ApiKey { get; set; }
        public Guid UserId { get; set; }
        public string PaymentReferenceType { get; set; }
        public decimal? Momspercent { get; set; }
        public bool? FeeIncludesMoms { get; set; }
        public bool? FeeExcludesMoms { get; set; }
        public int? MaxPaymentToProcess { get; set; }
        public string SpecificPaymentsToProcess { get; set; }
        public string CurrenciesToProcess { get; set; }

        public virtual User User { get; set; }
    }
}

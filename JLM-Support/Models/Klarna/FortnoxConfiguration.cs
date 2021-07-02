using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class FortnoxConfiguration
    {
        public Guid Id { get; set; }
        public byte ReferenceType { get; set; }
        public string AccessToken { get; set; }
        public string PaymentMethod { get; set; }
        public int MomsAccount { get; set; }
        public int InvoicingAccount { get; set; }
        public int FactoringAccount { get; set; }
        public int ServiceAccount { get; set; }
        public Guid UserId { get; set; }
        public bool PayInvoiceAmountOnly { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationNumber { get; set; }
        public string OrganisationEmail { get; set; }
        public DateTime? LastSuccessfulCheckedOn { get; set; }
        public string AccessTokenError { get; set; }
        public string DatabaseNumber { get; set; }

        public virtual User User { get; set; }
    }
}

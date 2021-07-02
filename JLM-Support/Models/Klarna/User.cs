using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class User
    {
        public User()
        {
            Payments = new HashSet<Payment>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Reference { get; set; }
        public int? MaxDaysToProcess { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationNumber { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public bool? TestMode { get; set; }
        public bool? DownloadNewPayments { get; set; }
        public bool? AddInvoice { get; set; }
        public bool? AddArticle { get; set; }

        public virtual FortnoxConfiguration FortnoxConfiguration { get; set; }
        public virtual KlarnaConfiguration KlarnaConfiguration { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

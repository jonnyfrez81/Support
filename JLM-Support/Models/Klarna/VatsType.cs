using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class VatsType
    {
        public VatsType()
        {
            AccountsConfigurations = new HashSet<AccountsConfiguration>();
        }

        public Guid Id { get; set; }
        public int Vat { get; set; }

        public virtual ICollection<AccountsConfiguration> AccountsConfigurations { get; set; }
    }
}

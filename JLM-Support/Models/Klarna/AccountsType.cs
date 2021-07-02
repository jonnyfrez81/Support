using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class AccountsType
    {
        public AccountsType()
        {
            AccountsConfigurations = new HashSet<AccountsConfiguration>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AccountsConfiguration> AccountsConfigurations { get; set; }
    }
}

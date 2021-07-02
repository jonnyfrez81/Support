using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.Klarna
{
    public partial class AccountsConfiguration
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VatsTypeId { get; set; }
        public Guid AccountsTypeId { get; set; }
        public Guid KlarnaOrderLinesTypeId { get; set; }
        public string Code { get; set; }
        public string AccountNumber { get; set; }

        public virtual AccountsType AccountsType { get; set; }
        public virtual KlarnaOrderLinesType KlarnaOrderLinesType { get; set; }
        public virtual VatsType VatsType { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.SieSync
{
    public partial class Voucher
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string FortnoxId { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string AccessToken { get; set; }
        public string Voucher1 { get; set; }
        public string VoucherNumber { get; set; }
    }
}

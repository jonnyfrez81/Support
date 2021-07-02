using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.SieSync
{
    public partial class VouchersQueue
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string FortnoxId { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string AccessToken { get; set; }
        public string Voucher { get; set; }
        public bool? Fail { get; set; }
        public string FailMessage { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.SieSync
{
    public partial class Log
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public string FortnoxId { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public string Message { get; set; }
    }
}

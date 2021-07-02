using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.PwcIca
{
    public partial class TblSetting
    {
        public int Id { get; set; }
        public string DatabaseId { get; set; }
        public string AuthorizationCode { get; set; }
        public string Accesstoken { get; set; }
        public string Companyname { get; set; }
        public string Moms25 { get; set; }
        public string Moms12 { get; set; }
        public string Moms6 { get; set; }
        public string Moms0 { get; set; }
        public bool? Active { get; set; }
        public string Voucherseries { get; set; }
    }
}

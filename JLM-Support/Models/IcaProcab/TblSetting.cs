using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.IcaProcab
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
        public string OreAdjAcc { get; set; }
        public string MomsXml25 { get; set; }
        public string MomsXml12 { get; set; }
        public string MomsXml6 { get; set; }
        public string MomsXml0 { get; set; }
    }
}

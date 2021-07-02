using System;
using System.Collections.Generic;

#nullable disable

namespace JLM_Support.Models.SieSync
{
    public partial class User
    {
        public string DatabasId { get; set; }
        public string Organisation { get; set; }
        public string OrganisationNumber { get; set; }
        public string FortnoxAccessToken { get; set; }
        public string EmailOrganisation { get; set; }
        public string Email { get; set; }
        public bool? AutoCreateAccount { get; set; }
        public bool? IsActive { get; set; }
        public int? MaxDayToProcess { get; set; }
        public bool? TestMode { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? LastSuccessfulCheck { get; set; }
        public string AccessTokenError { get; set; }
    }
}

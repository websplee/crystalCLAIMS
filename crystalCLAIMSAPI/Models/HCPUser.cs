using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class HCPUser : AuditableEntity, IEntityBase
    {
        public HCPUser()
        {
            ClaimsHCPInputers = new HashSet<Claim>();
            ClaimsHCPApprovers = new HashSet<Claim>();
            // ClaimsHCPInputer = new HashSet<Claim>();
            // CmTHcpMakerCheckerChecker = new HashSet<CmTHcpMakerChecker>();
            // CmTHcpMakerCheckerMaker = new HashSet<CmTHcpMakerChecker>();
        }

        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int HealthcareProviderId { get; set; }
        public bool? IsAdmin { get; set; } 
        public bool? IsActive { get; set; }
        public bool? IsMaker { get; set; }
        public bool? IsChecker { get; set; }

        public virtual ICollection<Claim> ClaimsHCPApprovers { get; set; }
        public virtual ICollection<Claim> ClaimsHCPInputers { get; set; }
        // public virtual ICollection<CmTHcpMakerChecker> CmTHcpMakerCheckerChecker { get; set; }
        // public virtual ICollection<CmTHcpMakerChecker> CmTHcpMakerCheckerMaker { get; set; }
        // public virtual AspNetUsers AspNetUser { get; set; }
        public virtual HealthcareProvider HealthcareProvider { get; set; }
    }
}
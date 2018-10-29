using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class IPUser : AuditableEntity, IEntityBase
    {
        public IPUser()
        {
            ClaimsIPFirstApprovers = new HashSet<Claim>();
            ClaimsIPSecondApprovers = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int InsuranceProviderId { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }


        public virtual ICollection<Claim> ClaimsIPFirstApprovers { get; set; }
        public virtual ICollection<Claim> ClaimsIPSecondApprovers { get; set; }
        // public virtual AspNetUsers AspNetUser { get; set; }
        public virtual InsuranceProvider InsuranceProvider { get; set; }
    }
}
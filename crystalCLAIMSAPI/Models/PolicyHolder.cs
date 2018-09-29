using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class PolicyHolder : AuditableEntity, IEntityBase
    {
        public PolicyHolder()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string PolicyHolderName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Telephone { get; set; }
        public string Telehpone1 { get; set; }
        public int? InsuranceProviderId { get; set; }
        public string PolicyNumber { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual InsuranceProvider InsuranceProvider { get; set; }
    }
}
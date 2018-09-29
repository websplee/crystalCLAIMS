using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class InsuranceProvider : AuditableEntity, IEntityBase
    {
        public InsuranceProvider()
        {
            PolicyHolders = new HashSet<PolicyHolder>();
            IPUsers = new HashSet<IPUser>();
        }

        public int Id { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public int DistrictId { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PolicyHolder> PolicyHolders { get; set; }
        public virtual ICollection<IPUser> IPUsers { get; set; }
        public virtual District District { get; set; }
    }
}
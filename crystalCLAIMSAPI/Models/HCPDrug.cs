using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class HCPDrug : AuditableEntity, IEntityBase
    {
        public HCPDrug()
        {
            ClaimDrugs = new HashSet<ClaimDrugs>();
        }
        public int Id { get; set; }
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int StandardDrugId { get; set; } // FK StandardService Id
        public double Price { get; set; } // The amount chargeable for this service at this clinic

        public virtual HealthcareProvider HealthcareProvider { get; set; }
        public virtual StandardDrug StandardDrug { get; set; }

        public virtual ICollection<ClaimDrugs> ClaimDrugs { get; set; }
    }
}

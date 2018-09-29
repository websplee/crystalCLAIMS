using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class HCPService : AuditableEntity, IEntityBase
    {
        public HCPService()
        {
            ClaimServices = new HashSet<ClaimServices>();
        }
        public int Id { get; set; }
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int StandardServiceProvidedId { get; set; } // FK StandardServiceProvided Id
        public double Price { get; set; } // The amount chargeable for this service at this clinic

        public virtual HealthcareProvider HealthcareProvider { get; set; }
        public virtual StandardServiceProvided StandardServiceProvided  { get; set; }

        public virtual ICollection<ClaimServices> ClaimServices { get; set; }

    }
}

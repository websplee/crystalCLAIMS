using System;
using crystalCLAIMSAPI.Models.Interfaces;
using System.Collections.Generic;

namespace crystalCLAIMSAPI.Models
{
    public class HCPDiagnosis : AuditableEntity, IEntityBase
    {
        public HCPDiagnosis()
        {
            ClaimDiagnoses = new HashSet<ClaimDiagnosis>();
        }

        public int Id { get; set; }
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int StandardDiagnosisId { get; set; } // FK StandardService Id
        public double Price { get; set; } // The amount chargeable for this service at this clinic

        public virtual HealthcareProvider HealthcareProvider { get; set; }
        public virtual StandardDiagnosis StandardDiagnosis { get; set; }

        public virtual ICollection<ClaimDiagnosis> ClaimDiagnoses { get; set; }
    }
}

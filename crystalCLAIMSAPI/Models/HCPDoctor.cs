using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class HCPDoctor : AuditableEntity, IEntityBase
    {
        public HCPDoctor()
        {
            ClaimDoctors = new HashSet<ClaimDoctors>();
        }

        public int Id { get; set; }
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int MedicalPersonnelId { get; set; } // FK Medical Personnel
        public string HCPEmployeeId { get; set; } // FK StandardService Id

        public virtual ICollection<ClaimDoctors> ClaimDoctors { get; set; }

        public virtual HealthcareProvider HCP { get; set; }
        public virtual MedicalPersonnel MedicalPersonnel { get; set; }
    }
}

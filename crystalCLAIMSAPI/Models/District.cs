using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class District : AuditableEntity, IEntityBase
    {
        public District()
        {
            HealthcareProviders = new HashSet<HealthcareProvider>();
            InsuranceProviders = new HashSet<InsuranceProvider>();
        }

        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int ProvinceId { get; set; }

        public virtual ICollection<HealthcareProvider> HealthcareProviders { get; set; }
        public virtual ICollection<InsuranceProvider> InsuranceProviders { get; set; }
        public virtual Province Province { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class HealthcareProvider : AuditableEntity, IEntityBase
    {
        public HealthcareProvider()
        {
            Claims = new HashSet<Claim>();
            HCPUsers = new HashSet<HCPUser>();
            HCPDoctors = new HashSet<HCPDoctor>();
            Diagnosis = new HashSet<HCPDiagnosis>();
            Drugs = new HashSet<HCPDrug>();            
            Services = new HashSet<HCPService>();
        }

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderCode { get; set; }
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
        public DateTime? JoiningDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<HCPDiagnosis> Diagnosis { get; set; }
        public virtual ICollection<HCPDrug> Drugs { get; set; } 
        public virtual ICollection<HCPService> Services { get; set; } 
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<HCPUser> HCPUsers { get; set; }
        public virtual ICollection<HCPDoctor> HCPDoctors { get; set; }
        public virtual District District { get; set; }

    }
}
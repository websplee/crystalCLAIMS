using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class MedicalPersonnel : AuditableEntity, IEntityBase
    {
        public MedicalPersonnel()
        {
            HCPDoctors = new HashSet<HCPDoctor>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Qualifications { get; set; }
        public string PracticingId { get; set; }

        public virtual ICollection<HCPDoctor> HCPDoctors { get; set; }
    }
}
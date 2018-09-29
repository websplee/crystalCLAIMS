using System;
using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class StandardDiagnosis : ServiceBase, IEntityBase
    {   
        public StandardDiagnosis()
        {
            HCPDiagnoses = new HashSet<HCPDiagnosis>();
        }
        public int Id { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<HCPDiagnosis> HCPDiagnoses { get; set; }
    }
}

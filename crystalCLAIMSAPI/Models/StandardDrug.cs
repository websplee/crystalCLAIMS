using System;
using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class StandardDrug : ServiceBase, IEntityBase
    {
        public StandardDrug()
        {
            HCPDrugs = new HashSet<HCPDrug>();
        }
        public int Id { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<HCPDrug> HCPDrugs { get; set; }
    }
}

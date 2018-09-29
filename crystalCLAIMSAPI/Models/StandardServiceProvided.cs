using System;
using System.Collections.Generic;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class StandardServiceProvided : ServiceBase, IEntityBase
    {
        public StandardServiceProvided()
        {
            HCPServices = new HashSet<HCPService>();
        }
        public int Id { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<HCPService> HCPServices { get; set; }
    }
}

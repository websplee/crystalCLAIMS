using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class StandardDrugViewModel
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public string Comment { get; set; }

        public ICollection<HCPDrugViewModel> HCPDrugs { get; set; }
    }
}

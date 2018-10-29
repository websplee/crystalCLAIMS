using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class HCPDrugViewModel
    {
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int StandardDrugId { get; set; } // FK StandardService Id
        public double Price { get; set; } // The amount chargeable for this service at this clinic

        public string ProviderName { get; set; } // Healthcare Provider name

        // Standard Items
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}

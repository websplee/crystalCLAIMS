using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ClaimDrugViewModel
    {
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDrugId { get; set; } // FK from HCP Drugs
        public int Quantity { get; set; }
        public double LineTotal { get; set; }

        // HCP Drug details
        public double Price { get; set; } // HCP specifig
        public string Shortname { get; set; }  // This must come all the way up from the Std drug
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ClaimServiceViewModel
    {
        public int ClaimId { get; set; } // FK from Claim
        public int HCPServiceId { get; set; } // FK from HCP Service
        public int Quantity { get; set; }
        public double LineTotal { get; set; }

        // HCP service details
        public double Price { get; set; } // HCP Specific
        public string Shortname { get; set; }  // This must come all the way up from the Std service
    }
}

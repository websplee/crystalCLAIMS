using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ClaimDiagnosisViewModel
    {
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDiagnosisId { get; set; } // FK from HCP Diagnosis
        public int Quantity { get; set; }
        public double LineTotal { get; set; }

        // HCP Diagnosis details
        public double Price { get; set; } // HCP Specific
        public string Shortname { get; set; }  // This must come all the way up from the Std diagnosis
    }
}

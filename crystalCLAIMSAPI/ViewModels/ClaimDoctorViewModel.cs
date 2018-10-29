using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ClaimDoctorViewModel
    {
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDoctorId { get; set; } // FK from HCP Doctor

        // Doctor Details
        public string DoctorFullName { get; set; }
    }
}

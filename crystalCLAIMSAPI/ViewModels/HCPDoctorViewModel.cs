using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.ViewModels
{
    public class HCPDoctorViewModel
    {
        public int HealthcareProviderId { get; set; } // FK HCP Id
        public int MedicalPersonnelId { get; set; } // FK Medical Personnel
        public string HCPEmployeeId { get; set; } // The employee ID for this Doctor

        public string ProviderName { get; set; } // Healthcare Provider name

        // Personal details
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Qualifications { get; set; }
        public string PracticingId { get; set; }

    }
}

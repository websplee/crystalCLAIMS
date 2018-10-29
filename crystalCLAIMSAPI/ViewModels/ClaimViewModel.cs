using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models;

namespace crystalCLAIMSAPI.ViewModels
{
    public class ClaimViewModel
    {
        public int? MemberId { get; set; }
        public int? HealthcareProviderId { get; set; }
        public string NameOfDoctor { get; set; }
        public string DoctorNumber { get; set; }
        public DateTime? ClaimInitiationDate { get; set; }
        public string HospitalizationEvent { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? ApprovedAmount { get; set; }
        // This is the status of the overall claim, is it with HCP or with IP
        public CustomEnums.ClaimStatus ClaimStatus { get; set; }
        public string ClaimComment { get; set; }
        public int? HCPInputerId { get; set; }
        public bool? HCPApprovalStatus { get; set; }
        public int? HCPApproverId { get; set; }
        public DateTime? HCPApprovalDate { get; set; }
        public bool? IPFirstApprovalStatus { get; set; }
        public string IPFirstApprovalComment { get; set; }
        public int? IPFirstApproverId { get; set; }
        public DateTime? IPFirstApproverChangeDate { get; set; }
        public bool? IPSecondApprovalStatus { get; set; }
        public string IPSecondApprovalComment { get; set; }
        public int? IPSecondApproverId { get; set; }
        public DateTime? IPSecondApproverChangeDate { get; set; }

        public ICollection<ClaimDoctorViewModel> ClaimDoctors { get; set; }
        public ICollection<ClaimDiagnosisViewModel> ClaimDiagnosis { get; set; }
        public ICollection<ClaimDrugViewModel> ClaimDrugs { get; set; }
        public ICollection<ClaimServiceViewModel> ClaimServices { get; set; }
    }
}

using System;
using crystalCLAIMSAPI.Models.Interfaces;
using System.Collections.Generic;

namespace crystalCLAIMSAPI.Models
{
    public class Claim : AuditableEntity, IEntityBase
    {
        public Claim()
        {
            ClaimDiagnosis = new HashSet<ClaimDiagnosis>();
            ClaimDrugs = new HashSet<ClaimDrugs>();
            ClaimServices = new HashSet<ClaimServices>();
            ClaimDoctors = new HashSet<ClaimDoctors>();
        }

        public int Id { get; set; }
        // public int? MainInsuredId { get; set; }
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

        public virtual ICollection<ClaimDoctors> ClaimDoctors { get; set; }
        public virtual ICollection<ClaimDiagnosis> ClaimDiagnosis { get; set; }
        public virtual ICollection<ClaimDrugs> ClaimDrugs { get; set; }
        public virtual ICollection<ClaimServices> ClaimServices { get; set; } 

        public virtual HCPUser HCPApprover { get; set; }
        public virtual HCPUser HCPInputer { get; set; }
        public virtual HealthcareProvider HCP { get; set; }
        public virtual IPUser IPFirstApprover { get; set; }
        public virtual IPUser IPSecondApprover { get; set; }
        public virtual Member Member { get; set; }

    }
}

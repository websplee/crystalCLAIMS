using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class ClaimDiagnosis : IEntityBase
    {
        public int Id { get; set; }
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDiagnosisId { get; set; } // FK from HCP Diagnosis

        public virtual Claim Claim { get; set; }
        public virtual HCPDiagnosis HCPDiagnosis{ get; set; }
    }
}

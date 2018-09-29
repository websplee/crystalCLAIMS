using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class ClaimDrugs : IEntityBase
    {
        public int Id { get; set; }
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDrugId { get; set; } // FK from HCP Drugs

        public virtual Claim Claim { get; set; }
        public virtual HCPDrug HCPDrug { get; set; }
    }
}

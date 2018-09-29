using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class ClaimDoctors : IEntityBase
    {
        public int Id { get; set; }
        public int ClaimId { get; set; } // FK from Claim
        public int HCPDoctorId { get; set; } // FK from HCP Doctor

        public virtual Claim Claim { get; set; }
        public virtual HCPDoctor HCPDoctor{ get; set; }
    }
}

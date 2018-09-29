using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ClaimDiagnosisRepository : EntityBaseRepository<ClaimDiagnosis>, IClaimDiagnosisRepository
    {
        public ClaimDiagnosisRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

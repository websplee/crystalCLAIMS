using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HCPDiagnosisRepository : EntityBaseRepository<HCPDiagnosis>, IHCPDiagnosisRepository
    {
        public HCPDiagnosisRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

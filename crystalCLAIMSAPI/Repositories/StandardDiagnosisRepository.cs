using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class StandardDiagnosisRepository : EntityBaseRepository<StandardDiagnosis>, IStandardDiagnosisRepository
    {
        public StandardDiagnosisRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

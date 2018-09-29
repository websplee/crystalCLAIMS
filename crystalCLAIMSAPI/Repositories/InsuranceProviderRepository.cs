using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class InsuranceProviderRepository : EntityBaseRepository<InsuranceProvider>, IInsuranceProviderRepository
    {
        public InsuranceProviderRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

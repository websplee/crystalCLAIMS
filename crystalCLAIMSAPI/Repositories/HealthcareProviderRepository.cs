using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HealthcareProviderRepository : EntityBaseRepository<HealthcareProvider>, IHealthcareProviderRepository
    {
        public HealthcareProviderRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

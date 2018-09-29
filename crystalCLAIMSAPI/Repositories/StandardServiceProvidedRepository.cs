using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class StandardServiceProvidedRepository : EntityBaseRepository<StandardServiceProvided>, IStandardServiceProvidedRepository
    {
        public StandardServiceProvidedRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

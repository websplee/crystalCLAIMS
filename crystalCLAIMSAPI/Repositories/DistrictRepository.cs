using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class DistrictRepository : EntityBaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

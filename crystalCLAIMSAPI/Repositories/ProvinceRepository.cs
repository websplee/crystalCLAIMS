using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ProvinceRepository  : EntityBaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class ClaimDoctorRepository : EntityBaseRepository<ClaimDoctors>, IClaimDoctorRepository
    {
        public ClaimDoctorRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

using crystalCLAIMSAPI.Data;
using crystalCLAIMSAPI.Models;
using crystalCLAIMSAPI.Repositories.Interfaces;

namespace crystalCLAIMSAPI.Repositories
{
    public class HCPDoctorRepository : EntityBaseRepository<HCPDoctor>, IHCPDoctorRepository
    {
        public HCPDoctorRepository(CrystalCLAIMSDbContext context)
            : base(context)
        { }
    }
}

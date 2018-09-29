using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models;

namespace crystalCLAIMSAPI.Data
{
    public class CrystalCLAIMSDbContext : DbContext
    {
        public int currentUserId { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimDiagnosis> ClaimDiagnosis { get; set; }
        public DbSet<ClaimDoctors> ClaimDoctors { get; set; }
        public DbSet<ClaimDrugs> ClaimDrugs { get; set; }
        public DbSet<ClaimServices> ClaimServices { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<HealthcareProvider> HealthcareProviders { get; set; }
        public DbSet<HCPUser> HCPUsers { get; set; }
        public DbSet<HCPDiagnosis> HCPDiagnosis { get; set; }
        public DbSet<HCPDoctor> HCPDoctor { get; set; }
        public DbSet<HCPDrug> HCPDrug { get; set; }
        public DbSet<HCPService> HCPService { get; set; }
        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
        public DbSet<IPUser> IPUsers { get; set; }
        public DbSet<MedicalPersonnel> MedicalPersonnels { get; set; }        
        public DbSet<Member> Members { get; set; }
        public DbSet<PolicyHolder> PolicyHolders { get; set; }
        public DbSet<StandardDiagnosis> StandardDiagnosis { get; set; }
        public DbSet<StandardDrug> StandardDrug { get; set; }
        public DbSet<StandardServiceProvided> StandardServiceProvided { get; set; }

        public CrystalCLAIMSDbContext(DbContextOptions<CrystalCLAIMSDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Claim>().ToTable("CCT_Claims");

            // Set relationship between Claims & HCPUsers
            // 1. HCP Inputer
            modelBuilder.Entity<Claim>()
                .HasOne(u => u.HCPInputer)
                .WithMany(c => c.ClaimsHCPInputers)
                .HasForeignKey(u => u.HCPInputerId);
            
            // 2. HCP Approver
            modelBuilder.Entity<Claim>()
                .HasOne(u => u.HCPApprover)
                .WithMany(c => c.ClaimsHCPApprovers)
                .HasForeignKey(u => u.HCPApproverId);

            // Set relationship between Claims & IPUsers
            // 1. IP First Approver
            modelBuilder.Entity<Claim>()
                .HasOne(u => u.IPFirstApprover)
                .WithMany(c => c.ClaimsIPFirstApprovers)
                .HasForeignKey(u => u.IPFirstApproverId);
            // 2. IP Second Approver
            modelBuilder.Entity<Claim>()
                .HasOne(u => u.IPSecondApprover)
                .WithMany(c => c.ClaimsIPSecondApprovers)
                .HasForeignKey(u => u.IPSecondApproverId);

            modelBuilder.Entity<ClaimDiagnosis>().ToTable("CCT_ClaimDiagnosis");
            modelBuilder.Entity<ClaimDoctors>().ToTable("CCT_ClaimDoctors");
            modelBuilder.Entity<ClaimDrugs>().ToTable("CCT_ClaimDrugs");
            modelBuilder.Entity<ClaimServices>().ToTable("CCT_ClaimServices");
            modelBuilder.Entity<District>().ToTable("CCT_Districts");
            modelBuilder.Entity<HCPUser>().ToTable("CCT_HCPUsers");
            modelBuilder.Entity<HCPDiagnosis>().ToTable("CCT_HCPDiagnosis");
            modelBuilder.Entity<HCPDoctor>().ToTable("CCT_HCPDoctors");
            modelBuilder.Entity<HCPDrug>().ToTable("CCT_HCPDrugs");
            modelBuilder.Entity<HCPService>().ToTable("CCT_HCPServices");
            modelBuilder.Entity<HealthcareProvider>().ToTable("CCT_HealthcareProviders");          
            modelBuilder.Entity<IPUser>().ToTable("CCT_IPUsers");
            modelBuilder.Entity<InsuranceProvider>().ToTable("CCT_InsuranceProviders");
            modelBuilder.Entity<MedicalPersonnel>().ToTable("CCT_MedicalPersonnel");
            modelBuilder.Entity<Member>().ToTable("CCT_Members");
            modelBuilder.Entity<PolicyHolder>().ToTable("CCT_PolicyHolders");
            modelBuilder.Entity<Province>().ToTable("CCT_Provinces");
            modelBuilder.Entity<StandardDiagnosis>().ToTable("CCT_StandardDiagnosis");
            modelBuilder.Entity<StandardDrug>().ToTable("CCT_StandardDrugs");
            modelBuilder.Entity<StandardServiceProvided>().ToTable("CCT_StandardServiceProvided");
        }
    }
}

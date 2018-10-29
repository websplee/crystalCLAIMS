using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using crystalCLAIMSAPI.Models;

namespace crystalCLAIMSAPI.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClaimDiagnosis, ClaimDiagnosisViewModel>()
                .ReverseMap();
            CreateMap<ClaimDoctors, ClaimDoctorViewModel>()
                .ReverseMap();
            CreateMap<ClaimDrugs, ClaimDrugViewModel>()
                .ReverseMap();
            CreateMap<ClaimServices, ClaimServiceViewModel>()
                .ReverseMap();
            CreateMap<Claim, ClaimViewModel>()
                .ReverseMap();
            CreateMap<District, DistrictViewModel>()
                .ReverseMap();
            CreateMap<HCPDiagnosis, HCPDiagnosisViewModel>()
                .ReverseMap();
            CreateMap<HCPDoctor, HCPDoctorViewModel>()
                .ReverseMap();
            CreateMap<HCPDrug, HCPDrugViewModel>()
                .ReverseMap();
            CreateMap<HCPService, HCPServiceViewModel>()
                .ReverseMap();
            CreateMap<HCPUser, HCPUserViewModel>()
                .ReverseMap();
            CreateMap<HealthcareProvider, HealthcareProviderViewModel>()
                .ReverseMap();
            CreateMap<InsuranceProvider, InsuranceProviderViewModel>()
                .ReverseMap();
            CreateMap<IPUser, IPUserViewModel>()
                .ReverseMap();
            CreateMap<MedicalPersonnel, MedicalPersonnelViewModel>()
                .ReverseMap();
            CreateMap<Member, MemberViewModel>()
                .ReverseMap();
            CreateMap<PolicyHolder, PolicyHolderViewModel>()
                .ReverseMap();
            CreateMap<ProvinceViewModel, ProvinceViewModel>()
                .ReverseMap();
            CreateMap<StandardDiagnosis, StandardDiagnosisViewModel>()
                .ReverseMap();
            CreateMap<StandardDrug, StandardDrugViewModel>()
                .ReverseMap();
            CreateMap<StandardServiceProvided, StandardServiceProvidedViewModel>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;
using Newtonsoft.Json;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceMotorDetailProfile : Profile
    {
        public InsuranceMotorDetailProfile()
        {
            CreateMap<InsuranceMotorDetail, InsuranceMotorDetailViewModel>()
                .ForMember(dest => dest.MotorType, opt => opt.MapFrom(src => MapMotorType(src.MotorType)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => Commons.Functions.MapEndDate(src.EffectiveDate, src.TimeCoverage)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Commons.Functions.MapInsuranceDetailStatus(src.Status)))
            ;

            CreateMap<InsuranceMotorDetail, CalculateInsurancePremiumDetailMotor>();

            CreateMap<InsuranceMotorDetail, CalculateInsurancePremium<CalculateInsurancePremiumDetailMotor>>()
                .ForMember(dest => dest.Insurance, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TimeCoverage, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TimeCoverageObjectString>(src.TimeCoverage)))
            ;

            CreateMap<InsuranceMotorDetail, BuyInsuranceMotorInsuranceDataViewModel>();

            CreateMap<InsuranceMotorDetail, BuyInsuranceMotorViewModel>()
                 .ForMember(dest => dest.Insurance, opt => opt.MapFrom(src => src))
                 .ForMember(dest => dest.TimeCoverage, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<TimeCoverageObjectString>(src.TimeCoverage)))
            ;

        }

        private string MapMotorType(MotorTypeEnum type)
        {
            if (type == MotorTypeEnum.OVER) return "trên 50cc";
            if (type == MotorTypeEnum.UNDER) return "dưới 50cc";
            if (type == MotorTypeEnum.TRICYCLE) return "xe ba bánh";
            if (type == MotorTypeEnum.OTHER) return "loại khác";
            return "";
        }

    }
}

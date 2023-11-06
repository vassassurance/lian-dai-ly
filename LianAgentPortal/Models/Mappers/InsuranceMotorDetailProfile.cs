using AutoMapper;
using LianAgentPortal.Commons.Enums;
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
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => MapEndDate(src.EffectiveDate, src.TimeCoverage)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapInsuranceDetailStatus(src.Status)))
                //
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

        private DateTime MapEndDate(DateTime effectiveDate, string TimeCoverageJsonString)
        {
            TimeCoverageObject timeCoverage = JsonConvert.DeserializeObject<TimeCoverageObject>(TimeCoverageJsonString);

            if (timeCoverage == null) return effectiveDate;

            if (timeCoverage.Unit == TimeCoverageUnitEnum.YEAR)
            {
                return effectiveDate.AddYears(timeCoverage.Value);
            }
            if (timeCoverage.Unit == TimeCoverageUnitEnum.MONTH)
            {
                return effectiveDate.AddMonths(timeCoverage.Value);
            }
            if (timeCoverage.Unit == TimeCoverageUnitEnum.DAY)
            {
                return effectiveDate.AddDays(timeCoverage.Value);
            }

            return effectiveDate;
        }

        private string MapInsuranceDetailStatus(InsuranceDetailStatusEnum status)
        {
            if (status == InsuranceDetailStatusEnum.NEW) return "<i class=\"fa fa-file-o\" aria-hidden=\"true\" title=\"TẠO MỚI\"></i>";

            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS) return "<i class=\"fa fa-check-square text-success\" aria-hidden=\"true\" title=\"TÍNH PHÍ - THÀNH CÔNG\"></i>";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR) return "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"TÍNH PHÍ - LỖI\"></i>";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS) return "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"ĐANG TÍNH PHÍ\"></i>";

            if (status == InsuranceDetailStatusEnum.SYNC_SUCCESS) return "<i class=\"fa fa-paper-plane text-success\" aria-hidden=\"true\" title=\"PHÁT HÀNH - THÀNH CÔNG\" ></i>";
            if (status == InsuranceDetailStatusEnum.SYNC_INPROGRESS) return "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"ĐANG PHÁT HÀNH\"></i>\"></i>";
            if (status == InsuranceDetailStatusEnum.SYNC_ERROR) return "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"PHÁT HÀNH - LỖI\"></i>";

            return "";
        }



    }
}

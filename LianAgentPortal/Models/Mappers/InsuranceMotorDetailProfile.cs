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
            if (status == InsuranceDetailStatusEnum.NEW) return "<i class=\"fa fa-file-o\" aria-hidden=\"true\"></i> TẠO MỚI";

            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS) return "<i class=\"fa fa-check-square\" aria-hidden=\"true\"></i> TÍNH PHÍ - THÀNH CÔNG";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR) return "<i class=\"fa fa-exclamation-triangle\" aria-hidden=\"true\"></i> TÍNH PHÍ - LỖI";
            if (status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS) return "<i class=\"fa fa-spinner\" aria-hidden=\"true\"></i> ĐANG TÍNH PHÍ";

            if (status == InsuranceDetailStatusEnum.SYNC_SUCCESS) return "<i class=\"fa fa-money\" aria-hidden=\"true\"></i> PHÁT HÀNH - THÀNH CÔNG";
            if (status == InsuranceDetailStatusEnum.SYNC_INPROGRESS) return "<i class=\"fa fa-spinner\" aria-hidden=\"true\"></i> ĐANG PHÁT HÀNH";
            if (status == InsuranceDetailStatusEnum.SYNC_ERROR) return "<i class=\"fa fa-exclamation-triangle\" aria-hidden=\"true\"></i> PHÁT HÀNH - LỖI";

            return "";
        }



    }
}

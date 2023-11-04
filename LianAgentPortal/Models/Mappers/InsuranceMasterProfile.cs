using AutoMapper;
using LianAgentPortal.Commons.Enums;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.Account;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceMasterProfile : Profile
    {
        public InsuranceMasterProfile()
        {
            CreateMap<InsuranceMaster, InsuranceMasterViewModel>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ConvertInsuranceTypeEnumToString(src.Type)))
                ;
        }

        private string ConvertInsuranceTypeEnumToString(InsuranceTypeEnum type)
        {
            if (type == InsuranceTypeEnum.FAMILY_BREADWINNER) return "<i class=\"fa fa-home\" aria-hidden=\"true\"></i> TRỤ CỘT GIA ĐÌNH";
            if (type == InsuranceTypeEnum.PERSONAL_ACCIDENT) return "<i class=\"fa fa-universal-access\" aria-hidden=\"true\"></i> TAI NẠN CÁ NHÂN";
            if (type == InsuranceTypeEnum.MOTORBIKE) return "<i class=\"fa fa-motorcycle\" aria-hidden=\"true\"></i> TNDS BB XE MÁY";
            return "";
        }

    }
}

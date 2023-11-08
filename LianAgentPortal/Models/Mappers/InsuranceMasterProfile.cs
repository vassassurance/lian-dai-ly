using AutoMapper;
using LianAgentPortal.Commons.Constants;
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
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Commons.Functions.ConvertInsuranceTypeEnumToString(src.Type)))
                ;
        }
    }
}

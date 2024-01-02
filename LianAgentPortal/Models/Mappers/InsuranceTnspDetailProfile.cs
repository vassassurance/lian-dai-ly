using AutoMapper;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.InsuranceTnspDetail;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceTnspDetailProfile : Profile
    {
        public InsuranceTnspDetailProfile()
        {
            CreateMap<InsuranceTnspDetail, InsuranceTnspDetailViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Commons.Functions.MapInsuranceOtherDetailStatus(src.Status)))
            ;
        }
    }
}

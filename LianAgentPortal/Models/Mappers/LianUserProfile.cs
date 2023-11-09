using AutoMapper;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.Account;

namespace LianAgentPortal.Models.Mappers
{
    public class LianUserProfile : Profile
    {
        public LianUserProfile()
        {
            CreateMap<LianUser, LianUserViewModel>()
                 .ForMember(dest => dest.AgentName, opt => opt.MapFrom(src => src.LianAgent != null ? src.LianAgent.Name : "" ))
            ;
        }
    }
}

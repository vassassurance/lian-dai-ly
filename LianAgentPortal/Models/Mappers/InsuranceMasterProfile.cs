using AutoMapper;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.Account;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceMasterProfile : Profile
    {
        public InsuranceMasterProfile()
        {
            CreateMap<InsuranceMaster, InsuranceMasterViewModel>();
        }
    }
}

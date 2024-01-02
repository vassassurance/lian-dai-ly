using AutoMapper;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.InsuranceTnspMaster;

namespace LianAgentPortal.Models.Mappers
{
    public class InsuranceTnspMasterProfile : Profile
    {
        public InsuranceTnspMasterProfile()
        {
            CreateMap<InsuranceTnspMaster, InsuranceTnspMasterViewModel>();
        }
    }
}

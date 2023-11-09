using LianAgentPortal.Commons.Attributes;
using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.InsuranceMaster
{
    public class DeleteInsuranceMasterViewModel
    {
        [Required]
        public long Id { get; set; }
    }
}

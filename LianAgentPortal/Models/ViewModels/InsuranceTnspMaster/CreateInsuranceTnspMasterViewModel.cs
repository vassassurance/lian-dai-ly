using LianAgentPortal.Commons.Attributes;
using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.InsuranceTnspMaster
{
    public class CreateInsuranceTnspMasterViewModel
    {
        [Required(ErrorMessage = "Hãy chọn file")]
        [Display(Name = "File excel")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".xls", ".xlsx" })]
        public IFormFile ReportFile { set; get; }
    }
}

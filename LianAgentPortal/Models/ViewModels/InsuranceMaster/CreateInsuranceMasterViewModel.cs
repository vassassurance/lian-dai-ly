using LianAgentPortal.Commons.Attributes;
using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.InsuranceMaster
{
    public class CreateInsuranceMasterViewModel
    {
        public InsuranceTypeEnum Type { get; set; }

        [Required(ErrorMessage = "Hãy chọn file")]
        [Display(Name = "File excel")]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".xls", ".xlsx" })]
        public IFormFile ReportFile { set; get; }
    }
}

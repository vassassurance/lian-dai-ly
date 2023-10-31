using System.ComponentModel.DataAnnotations;


namespace LianAgentPortal.Models.ViewModels.Authentication
{
    public class ConfirmChangePasswordViewModel
    {
        [Required]
        public string Code { get; set; }
    }
}

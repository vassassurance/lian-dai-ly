using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.Account
{
    public class CreateLianUserViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} tối thiểu {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} tối thiểu {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận password")]
        [Compare("Password", ErrorMessage = "Không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Quyền admin")]
        public bool IsAdmin { get; set; }
    }
}

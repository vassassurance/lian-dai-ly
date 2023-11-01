using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.Account
{
    public class EditLianUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Giá trị không đúng")]
        [Display(Name = "Đại lý")]
        public long AgentId { get; set; }

        [StringLength(100, ErrorMessage = "{0} tối thiểu {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận password")]
        [Compare("Password", ErrorMessage = "Không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tình Trạng")]
        public bool IsActivated { get; set; }

        [Display(Name = "Quyền admin")]
        public bool IsAdmin { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.Account
{
    public class CreateLianUserViewModel
    {
        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Giá trị không đúng")]
        [Display(Name = "Đại lý")]
        public long AgentId { get; set; }

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

        [Required]
        [Display(Name = "Họ tên")]
        public string Fullname { get; set; }

        [Display(Name = "Ghi chú")]
        public string Description { get; set; }


        [Display(Name = "Quyền admin")]
        public bool IsAdmin { get; set; }
    }
}

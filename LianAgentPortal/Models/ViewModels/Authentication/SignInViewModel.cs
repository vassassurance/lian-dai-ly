using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.Authentication
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Pin")]
        public string Pin { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

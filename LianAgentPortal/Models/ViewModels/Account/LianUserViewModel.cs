using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.Account
{
    public class LianUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Đại lý")]
        public string AgentName { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }


        [Display(Name = "Họ tên")]
        public string Fullname { get; set; }

        [Display(Name = "Ghi chú")]
        public string Description { get; set; }


        [Display(Name = "GG Authenticator")]
        public string QrCode { get; set; }

        [Display(Name = "Tình Trạng")]
        public bool IsActivated { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Ngày update")]
        public DateTime? UpdateDate { get; set; }

        [Display(Name = "Quyền admin")]
        public bool IsAdmin { get; set; }
    }
}

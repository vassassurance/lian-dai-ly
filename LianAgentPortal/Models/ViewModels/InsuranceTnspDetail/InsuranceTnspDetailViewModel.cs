using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.ViewModels.InsuranceTnspDetail
{
    public class InsuranceTnspDetailViewModel
    {
        public long Id { get; set; }
        public string CertificateDigitalLink { get; set; }
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string InsuranceNo { get; set; }
        public decimal Premium { get; set; }
        public decimal InsuranceAmount { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}

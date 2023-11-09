using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.ViewModels.InsuranceAutomobileDetail
{
    public class InsuranceAutomobileDetailViewModel
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public string PartnerTransaction { get; set; }
        public string Transaction { get; set; }
        public string InsuranceCode { get; set; }
        public string CertificateDigitalLink { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Amount { get; set; }
        public string LicensePlates { get; set; }
        public string FullTypeName { get; set; }
        public string Fullname { get; set; }
        public string ChassisNumber { get; set; }
        public string MachineNumber { get; set; }
        public long PassengerFee { get; set; }
        public long PassengerCount { get; set; }
        public long LiabilityInsuranceFee { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

    }
}

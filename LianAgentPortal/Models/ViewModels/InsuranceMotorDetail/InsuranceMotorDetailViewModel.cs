using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.ViewModels.InsuranceMotorDetail
{
    public class InsuranceMotorDetailViewModel
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string PartnerTransaction { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? Amount { get; set; }
        public string LicensePlates { get; set; }
        public string MotorType { get; set; }
        public string ChassisNumber { get; set; }
        public string MachineNumber { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public bool PassengerInsurance { get; set; }
        public DateTime? Birhtday { get; set; }
    }
}

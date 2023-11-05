using LianAgentPortal.Commons.Enums;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.ViewModels.InsuranceMotorDetail
{
    public class BuyInsuranceMotorViewModel
    {
        public string AgentPhone { get; set; }
        public string PartnerTransaction { get; set; }
        public DateTime EffectiveDate { get; set; }
        public TimeCoverageObjectString TimeCoverage { get; set; }
        public decimal? Amount { get; set; }

        public BuyInsuranceMotorInsuranceDataViewModel Insurance { get; set; }

        public string Language { get; set; }
        public string Type { get; set; }
    }

    public class BuyInsuranceMotorInsuranceDataViewModel
    {
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

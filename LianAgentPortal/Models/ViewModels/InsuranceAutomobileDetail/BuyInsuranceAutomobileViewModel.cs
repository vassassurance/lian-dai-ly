using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;

namespace LianAgentPortal.Models.ViewModels.InsuranceAutomobileDetail
{
    public class BuyInsuranceAutomobileViewModel
    {
        public string AgentPhone { get; set; }
        public string PartnerTransaction { get; set; }
        public DateTime EffectiveDate { get; set; }
        public TimeCoverageObjectString TimeCoverage { get; set; }
        public long Amount { get; set; }

        public BuyInsuranceAutomobileInsuranceDataViewModel Insurance { get; set; }

        public string Language { get; set; }
        public string Type { get; set; }
    }

    public class BuyInsuranceAutomobileInsuranceDataViewModel
    {
        public string LicensePlates { get; set; }
        public string AutomobilesType { get; set; }
        public AutomobileAttributesString Attributes { get; set; }

        public string Fullname { get; set; }
        public string ChassisNumber { get; set; }
        public string MachineNumber { get; set; }
        public long PassengerFee { get; set; }
        public long PassengerCount { get; set; }
        public long LiabilityInsuranceFee { get; set; }

        public string Phone { get; set; }
        public string Email { get; set;  }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}

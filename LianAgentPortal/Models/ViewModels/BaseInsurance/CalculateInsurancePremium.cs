using LianAgentPortal.Commons.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public interface ICalculateInsurancePremiumDetail
    {

    }

    public class CalculateInsurancePremium<T> where T : ICalculateInsurancePremiumDetail
    {
        public DateTime EffectiveDate { get; set; }
        public TimeCoverageObjectString TimeCoverage { get; set; }
        public T Insurance { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
    }

    public class CalculateInsurancePremiumDetailPersonalAccident : ICalculateInsurancePremiumDetail
    {
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public PersonalAccidentRankEnum Ranking { get; set; }
    }

    public class CalculateInsurancePremiumDetailFamilyBreadwinner : ICalculateInsurancePremiumDetail
    {
        public FamilyBreadwinnerRankEnum Ranking { get; set; }
    }

    public class CalculateInsurancePremiumDetailMotor : ICalculateInsurancePremiumDetail
    {
        public bool PassengerInsurance { get; set; }
        public string MotorType { get; set; }
    }
}

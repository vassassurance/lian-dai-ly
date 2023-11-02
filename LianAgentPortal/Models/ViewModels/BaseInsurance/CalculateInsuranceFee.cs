using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public interface ICalculateInsuranceFeeDetail
    {

    }

    public class CalculateInsuranceFee<T> where T : ICalculateInsuranceFeeDetail
    {
        public DateTime EffectiveDate { get; set; }
        public TimeCoverageObject TimeCoverage { get; set; }
        public T Insurance { get; set; }
        public InsuranceTypeEnum Type { get; set; }
        public string Language { get; set; }
    }

    public class CalculateInsuranceFeeDetailPersonalAccident : ICalculateInsuranceFeeDetail
    {
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public PersonalAccidentRankEnum Ranking { get; set; }
    }

    public class CalculateInsuranceFeeDetailFamilyBreadwinner : ICalculateInsuranceFeeDetail
    {
        public FamilyBreadwinnerRankEnum Ranking { get; set; }
    }

    public class CalculateInsuranceFeeDetailMotor : ICalculateInsuranceFeeDetail
    {
        public bool PassengerInsurance { get; set; }
        public string MotorType { get; set; }
    }
}

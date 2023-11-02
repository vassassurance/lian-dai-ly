using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.DbModels
{
    public class BaseInsuranceDetail
    {
        public ulong Id { get; set; }
        public string AgentPhone { get; set; }
        public string PartnerTransaction { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string TimeCoverage { get; set; }
        public decimal Amount { get; set; }
        public string Language { get; set; }
        public InsuranceTypeEnum Type { get; set; }
    }
}

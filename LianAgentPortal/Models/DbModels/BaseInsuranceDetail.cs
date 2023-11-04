using LianAgentPortal.Commons.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LianAgentPortal.Models.DbModels
{
    [Index("Type", IsUnique = false)]
    [Index("Status", IsUnique = false)]
    public class BaseInsuranceDetail
    {
        public long Id { get; set; }

        [ForeignKey("InsuranceMaster")]
        public long InsuranceMasterId { get; set; }
        public InsuranceMaster InsuranceMaster { get; set; }

        public InsuranceDetailStatusEnum Status { get; set; }

        public string AgentPhone { get; set; }
        public string PartnerTransaction { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string TimeCoverage { get; set; }
        public decimal? Amount { get; set; }
        public string Language { get; set; }
        public InsuranceTypeEnum Type { get; set; }
    }
}

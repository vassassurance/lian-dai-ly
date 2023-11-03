using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.DbModels
{
    public class InsurancePersonalAccidentDetail : BaseInsuranceDetail
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? Birhtday { get; set; }
        public PersonalAccidentRankEnum Ranking { get; set; }
    }
}

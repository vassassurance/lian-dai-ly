using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.DbModels
{
    public class InsuranceDetailFamilyBreadwinner : BaseInsuranceDetail
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public GenderEnum Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? Birhtday { get; set; }
        public FamilyBreadwinnerRankEnum Ranking { get; set; }
    }
}

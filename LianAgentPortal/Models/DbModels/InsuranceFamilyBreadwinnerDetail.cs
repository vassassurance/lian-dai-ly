using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Models.DbModels
{
    public class InsuranceFamilyBreadwinnerDetail : BaseInsuranceDetail
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public GenderEnum Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? Birhtday { get; set; }
        public FamilyBreadwinnerRankEnum Ranking { get; set; }
    }
}

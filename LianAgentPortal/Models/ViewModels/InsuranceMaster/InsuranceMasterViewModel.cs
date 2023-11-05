using LianAgentPortal.Commons.Enums;

namespace LianAgentPortal.Models.ViewModels.InsuranceMaster
{
    public class InsuranceMasterViewModel
    {
        public long Id { get; set; }
        public string UserCreate { get; set; }
        public DateTime DateCreate { get; set; }
        public string LastUserUpdate { get; set; }
        public DateTime? LastDateUpdate { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }

        public int TotalRows { get; set; }
        public int TotalIssuedRows { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalInsuranceAmount { get; set; }
        public string Type { get; set; }
    }
}

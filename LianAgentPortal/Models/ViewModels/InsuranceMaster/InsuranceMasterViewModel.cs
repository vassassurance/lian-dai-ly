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

        public int TotalRows { get; set; }
        public int TotalIssuedRows { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalInsuranceAmount { get; set; }
        public InsuranceTypeEnum Type { get; set; }
        public string TypeName 
        { 
            get 
            {
                if (Type == InsuranceTypeEnum.FAMILY_BREADWINNER) return "<i class=\"fa fa-home\" aria-hidden=\"true\"></i> TRỤ CỘT GIA ĐÌNH";
                if (Type == InsuranceTypeEnum.PERSONAL_ACCIDENT) return "<i class=\"fa fa-universal-access\" aria-hidden=\"true\"></i> TAI NẠN CÁ NHÂN";
                if (Type == InsuranceTypeEnum.MOTORBIKE) return "<i class=\"fa fa-motorcycle\" aria-hidden=\"true\"></i> TNDS BB XE MÁY";
                return "";
            } 
        }
    }
}

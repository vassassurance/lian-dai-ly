using DocumentFormat.OpenXml.Wordprocessing;
using LianAgentPortal.Commons.Constants;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.LianInsurance
{
    public class LianInsuranceSearchResponseViewModel
    {
        public LianInsuranceSearchResponseViewModel()
        {
            this.Data = new List<LianInsuranceSearchResponseDataViewModel>();
        }
        public long Code { get; set; }
        public string Message { get; set; }
        public List<LianInsuranceSearchResponseDataViewModel> Data { get; set; }
    }

    public class LianInsuranceSearchResponseDataViewModel
    {
        public string AgentName { get; set; }
        public string UserCreate { get; set; }
        public string Transaction { get; set; }

        public InsuranceTypeEnum Type { get; set; }
        public string TypeName
        {
            get
            {
                return Commons.Functions.ConvertInsuranceTypeEnumToString(this.Type);
            }
        }
        public string LicensePlates_IdentityNumber { get; set; }
        public string CertificateDigitalLink { get; set; }
        public string PackageName { get; set; }
        public string Fullname { get; set; }
        public string ExpiredDate { get; set; }
        public string EffectiveDate { get; set; }
        public string InsuranceCode { get; set; }

        public LianInsuranceStateEnum State { get; set; }
        public string StateName
        {
            get
            {
                var result = LianInsuranceStateConstants.Data.FirstOrDefault(item => item.TypeEnum == State);
                if (result == null) return "";

                return result.TypeNameIcon + " " + result.TypeName;
            }
        }
        public long NetAmount { get; set; }
        public long VatAmount { get; set; }
        public long NntxAmount { get; set; }

        public long Amount { get; set; }
        public long Sponsor { get; set; }
        public long Income { get; set; }
        public string Time { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}

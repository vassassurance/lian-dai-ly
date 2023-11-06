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
        public string Transaction { get; set; }
        public string Type { get; set; }
        public string PackageName { get; set; }
        public string Fullname { get; set; }
        public string ExpiredDate { get; set; }
        public string EffectiveDate { get; set; }
        public string InsuranceCode { get; set; }
        public string State { get; set; }
        public long Amount { get; set; }
        public long Sponsor { get; set; }
        public long Income { get; set; }
        public string Time { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}

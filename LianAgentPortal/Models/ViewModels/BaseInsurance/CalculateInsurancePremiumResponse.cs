namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public class CalculateInsurancePremiumResponse
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public CalculateInsurancePremiumResponseData Data { get; set; }
    }

    public class CalculateInsurancePremiumResponseData
    {
        public decimal TotalAmount { get; set; }
    }
}

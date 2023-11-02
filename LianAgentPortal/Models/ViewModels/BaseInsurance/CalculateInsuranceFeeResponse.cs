namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public class CalculateInsuranceFeeResponse
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public CalculateInsuranceFeeResponseData Data { get; set; }
    }

    public class CalculateInsuranceFeeResponseData
    {
        public decimal TotalAmount { get; set; }
    }
}

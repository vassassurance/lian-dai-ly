namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public class BuyInsuranceApiResponse
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public BuyInsuranceApiResponseData Data { get; set; }
    }

    public class BuyInsuranceApiResponseData
    {
        public string PartnerTransaction { get; set; }
        public TimeCoverageObject TimeCoverage { get; set; }
        public string CertificateDigitalLink { get; set; }
        public DateTime ExpiredDate { get; set; }
        public bool PassengerInsurance { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Fullname { get; set; }
        public string LicensePlates { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string MachineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public string MotorType { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Transaction { get; set; }
        public string InsuranceCode { get; set; }
        public string Ranking { get; set; }
        public string State { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

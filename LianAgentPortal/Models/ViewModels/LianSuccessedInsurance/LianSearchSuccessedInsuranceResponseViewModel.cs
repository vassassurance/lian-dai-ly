using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Models.ViewModels.LianSuccessedInsurance
{

    public class LianSearchSuccessedInsuranceResponseViewModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public int totalRecord { get; set; }
        public List<LianSuccessedInsuranceResponseViewModel> data { get; set; }
    }

    public class LianSuccessedInsuranceResponseViewModel
    {
        public InsuranceTypeEnum type { get; set; }
        public string state { get; set; }
        public int amount { get; set; }
        public object[] indemnify { get; set; }
        public long accountId { get; set; }
        public string transaction { get; set; }
        public Package package { get; set; }
        public Extradata extraData { get; set; }
        public string insuranceCode { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime paymentAt { get; set; }
        public int id { get; set; }
    }

    public class Package
    {
        public int id { get; set; }
        public string name { get; set; }
        public string template { get; set; }
    }

    public class Extradata
    {
        public string effectiveDate { get; set; }
        public string expiredDate { get; set; }
        public Timecoverage timeCoverage { get; set; }
        public string fullname { get; set; }
        public string identityNumber { get; set; }
        public DateTime birthday { get; set; }
        public string gender { get; set; }
        public string ranking { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string licensePlates { get; set; }
        public string machineNumber { get; set; }
        public string chassisNumber { get; set; }
        public string automobilesType { get; set; }
        public int liabilityInsuranceFee { get; set; }
        public Attributes attributes { get; set; }
        public bool passengerInsurance { get; set; }
        public object[] userAnswers { get; set; }
        public int passengerCount { get; set; }
        public int passengerFee { get; set; }
        public string phone { get; set; }
        public object description { get; set; }
        public Tripinfo[] tripInfos { get; set; }
        public Insurancerecipient[] insuranceRecipients { get; set; }
        public string errorFullName { get; set; }
        public string errorIdentityNumber { get; set; }
        public string motorType { get; set; }
    }

    public class Timecoverage
    {
        public string unit { get; set; }
        public int value { get; set; }
    }

    public class Attributes
    {
        public string seat { get; set; }
        public string category { get; set; }
    }

    public class Tripinfo
    {
        public string destination { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }

    public class Insurancerecipient
    {
        public string fullname { get; set; }
        public string identityNumber { get; set; }
        public string errorFullName { get; set; }
        public string errorIdentityNumber { get; set; }
    }


}

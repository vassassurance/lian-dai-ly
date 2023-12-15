using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Models.DbModels
{
    public class InsuranceAutomobileDetail : BaseInsuranceDetail
    {
        public string LicensePlates { get; set; }
        public AutomobileTypeEnum AutomobilesType { get; set; }
        public string Attributes_Seat { get; set; }
        public AutomobileTypeCategoryEnum Attributes_Category { get; set; }
        public string Fullname { get; set; }
        public string ChassisNumber { get; set; }
        public string MachineNumber { get; set; }
        public long PassengerFee { get; set; }
        public long PassengerCount { get; set; }
        public long LiabilityInsuranceFee { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public GenderEnum Gender { get; set; }
        public string Description { get; set; }
        public string PaperCertificateNo { get; set; }
        public string PaperCertificatePath { get; set; }
    }
}

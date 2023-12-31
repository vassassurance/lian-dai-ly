﻿using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Models.DbModels
{
    public class InsuranceMotorDetail : BaseInsuranceDetail
    {
        public string LicensePlates { get; set; }
        public MotorTypeEnum MotorType { get; set; }
        public string ChassisNumber { get; set; }
        public string MachineNumber { get; set; }

        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public bool PassengerInsurance { get; set; }
        public DateTime? Birhtday { get; set; }
        public string PaperCertificateNo { get; set; }
        public string PaperCertificatePath { get; set; }
    }
}

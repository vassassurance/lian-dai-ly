using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Models.ViewModels.LianInsurance
{
    public class LianInsuranceDetailResponseViewModel
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public LianInsuranceDetailResponseDataViewModel Data { get; set; }
    }


    public class LianInsuranceDetailResponseDataViewModel
    {
        [Display(Name = "Mã giao dịch")]
        public string Transaction { get; set; }

        public string PartnerTransaction { get; set; }

        [Display(Name = "Số GCN")]
        public string InsuranceCode { get; set; }
        public string PackageName { get; set; }
        public InsuranceTypeEnum Type { get; set; }

        [Display(Name = "Tên gói bảo hiểm")]
        public string TypeName
        {
            get
            {
                return Commons.Functions.ConvertInsuranceTypeEnumToString(this.Type);
            }
        }

        public LianInsuranceStateEnum State { get; set; }

        [Display(Name = "Trạng thái")]
        public string StateName
        {
            get
            {
                var result = LianInsuranceStateConstants.Data.FirstOrDefault(item => item.TypeEnum == State);
                if (result == null) return "";

                return result.TypeName;
            }
        }

        public string StateIcon
        {
            get
            {
                var result = LianInsuranceStateConstants.Data.FirstOrDefault(item => item.TypeEnum == State);
                if (result == null) return "";

                return result.TypeNameIcon;
            }
        }


        public List<string> CertificateDigitalLink { get; set; }

        public string CertificateDigitalLinkToDownLoad
        {
            get
            {
                if (CertificateDigitalLink != null && CertificateDigitalLink.Count > 0)
                {
                    return CertificateDigitalLink.FirstOrDefault();
                }
                return null;
            }
            
        }

        [Display(Name = "Hiệu lực từ")]
        public DateTime EffectiveDate { get; set; }

        [Display(Name = "Hiệu lực đến")]
        public DateTime ExpiredDate { get; set; }
        public TimeCoverageObject TimeCoverage { get; set; }

        [Display(Name = "Họ & tên")]
        public string Fullname { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        public GenderEnum Gender { get; set; }

        [Display(Name = "Hạng bảo hiểm")]
        public string Ranking { get; set; }

        [Display(Name = "CMND/CCCD")]
        public string IdentityNumber { get; set; }

        [Display(Name = "Biển số")]
        public string LicensePlates { get; set; }

        [Display(Name = "Số khung")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Số máy")]
        public string MachineNumber { get; set; }


        public MotorTypeEnum MotorType { get; set; }
        [Display(Name = "Loại xe")]
        public string MotorTypeName
        {
            get
            {
                var result = MotorTypeConstants.Data.FirstOrDefault(item => item.TypeEnum == MotorType);
                if (result == null) return "";

                return result.TypeName;
            }
        }


        public bool PassengerInsurance { get; set; }

        [Display(Name = "Tham gia bảo hiểm người ngồi")]
        public string PassengerInsuranceStr
        {
            get
            {
                return PassengerInsurance ? "CÓ" : "KHÔNG";
            }
        }

        [Display(Name = "Tạo lúc")]
        public DateTime CreatedAt { get; set; }

        public AutomobileTypeEnum AutomobilesType { get; set; }

        [Display(Name = "Loại xe")]
        public string AutomobilesTypeName
        {
            get
            {
                var result = AutomobileTypeConstants.Data.FirstOrDefault(item => item.TypeEnum == AutomobilesType);
                if (result == null) return "";

                return result.TypeName;
            }
        }

        public AutomobileAttributes Attributes { get; set; }

        [Display(Name = "Số chổ")]
        public string AutomobileAttributesSeat
        {
            get
            {
                if (Attributes != null)
                {
                    return Attributes.Seat;
                }
                return "";
            }
        }

        [Display(Name = "Chi tiết loại xe/ trọng tải")]
        public string AutomobileAttributesCategoryName
        {
            get
            {
                if (Attributes == null) return "";
                var result = AutomobileTypeCategoryConstants.Data.FirstOrDefault(item => item.TypeEnum == Attributes.Category);
                if (result == null) return "";

                return result.TypeName;
            }
        }


        [Display(Name = "Phí tai nạn người ngồi")]
        public long PassengerFee { get; set; }

        [Display(Name = "Số chổ tham gia TNNN")]
        public long PassengerCount { get; set; }

        [Display(Name = "Phí TNDS BB")]
        public long LiabilityInsuranceFee { get; set; }
    }

}

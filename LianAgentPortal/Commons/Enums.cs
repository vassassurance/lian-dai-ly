using DocumentFormat.OpenXml.Drawing.Charts;
using System.Runtime.Serialization;

namespace LianAgentPortal.Commons.Enums
{
    public enum InsuranceDetailStatusEnum
    {
        NEW = 100,

        CALCULATE_PREMIUM_INPROGRESS = 200,
        CALCULATE_PREMIUM_SUCCESS = 210,
        CALCULATE_PREMIUM_ERROR = -220,
        
        SYNC_INPROGRESS = 300,
        SYNC_SUCCESS = 310,
        SYNC_ERROR = -310,
    }
    public enum InsuranceTypeEnum
    {
        MOTORBIKE = 100,
        FAMILY_BREADWINNER = 200,
        PERSONAL_ACCIDENT = 300,
        BREAST_CANCER = 400,
        AUTOMOBILES = 500
    }

    public enum MotorTypeEnum
    {
        UNDER = 100,
        OVER = 200,
        TRICYCLE = 300,
        OTHER = 400
    }

    public enum AutomobileTypeEnum
    {
        NON_COMMERCIAL = 100,
        BUS = 200,
        COMMERCIAL = 300,
        DELIVERY_TRUCK = 400,
        MINI_VAN = 500,
        TAXI = 600,
        CONTAINER = 700,
        SPECIALIZED = 800,
        TRAINER = 900,
        TRAINER_TRUCK = 1000
    }

    public enum AutomobileTypeCategoryEnum
    {
        NON_COMMERCIAL = 100,
        COMMERCIAL = 300,
        UNDER_THREE_TONS = 400,
        THREE_TO_EIGHT_TONS = 500, 
        EIGHT_TO_FIFTEEN_TONS = 600,
        OVER_FIFTEEN_TONS = 700,
        MONEY_TRUCK = 800,
        AMBULANCE = 900,
        TRAINER = 1000,
        TRAINER_TRUCK = 1100
    }

    public enum PersonalAccidentRankEnum
    {
        BRONZE = 100,
        SILVER = 200,
        GOLD = 300
    }

    public enum FamilyBreadwinnerRankEnum
    {
        GOLD = 300,
        DIAMOND = 400
    }

    public enum GenderEnum
    {
        MALE = 1,
        FEMALE = 0
    }

    public enum TimeCoverageUnitEnum
    {
        DAY = 1,
        MONTH = 30,
        YEAR = 365
    }

    public enum CalculateInsurancePremiumResultEnum
    {
        SUCCESS = 303800,
        ERROR = 303801
    }

    public enum BuyInsuranceResultEnum
    {
        /// <summary>
        /// 303300: Tạo đơn thanh toán thành công
        /// </summary>
        SUCCESS = 303300,

        /// <summary>
        /// //303301: Tạo đơn thanh toán thất bại
        /// </summary>
        CREATE_PAYMENT_FAILED = 303301,

        /// <summary>
        /// 303303: Thông tin bảo hiểm đã tồn tại trong hệ thống và còn hiệu lực
        /// </summary>
        OVERLAPPED = 303303,

        /// <summary>
        /// 303305: Ngày hiệu lực không hợp lệ
        /// </summary>
        INVALID_INSURED_RANGE = 303305,

        /// <summary>
        /// 303307: Tài khoản không phải là đại lý
        /// </summary>
        NOT_AGENT_ACCOUNT = 303307,

        /// <summary>
        /// 303309: Không tìm thấy thông tin tài khoản
        /// </summary>
        ACCOUNT_NOT_FOUNT = 303309,

        /// <summary>
        /// 3033011: Parameter không đúng định dạng
        /// </summary>
        INVALID_PARAMETERS = 3033011,

        /// <summary>
        /// -1: Lỗi khác
        /// </summary>
        UNKNOWN_ERROR = -1
    }

}

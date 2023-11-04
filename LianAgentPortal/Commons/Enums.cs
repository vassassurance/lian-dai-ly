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
        PERSONAL_ACCIDENT = 300
    }

    public enum MotorTypeEnum
    {
        UNDER = 100,
        OVER = 200,
        TRICYCLE = 300,
        OTHER = 400
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
}

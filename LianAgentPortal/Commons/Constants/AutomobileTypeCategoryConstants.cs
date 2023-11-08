using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace LianAgentPortal.Commons.Constants
{
    public static class AutomobileTypeCategoryConstants
    {
        public static List<AutomobileTypeCategoryObject> Data = new List<AutomobileTypeCategoryObject>()
        {
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.NON_COMMERCIAL,  TypeName = "Xe không kinh doanh" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.COMMERCIAL,  TypeName = "Xe kinh doanh" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.UNDER_THREE_TONS,  TypeName = "Xe dưới 3 tấn" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.THREE_TO_EIGHT_TONS,  TypeName = "Xe từ 3 đến 8 tấn" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.EIGHT_TO_FIFTEEN_TONS,  TypeName = "Xe từ 8 đến 15 tấn" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.OVER_FIFTEEN_TONS,  TypeName = "Xe trên 15 tấn" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.MONEY_TRUCK,  TypeName = "Xe chở tiền" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.AMBULANCE,  TypeName = "Xe cứu thương" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.TRAINER,  TypeName = "Xe tập lái" },
            new AutomobileTypeCategoryObject() { TypeEnum = AutomobileTypeCategoryEnum.TRAINER_TRUCK,  TypeName = "Xe tải tập lái" }
        };

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

    public class AutomobileTypeCategoryObject
    {
        public AutomobileTypeCategoryEnum TypeEnum { get; set; }
        public string TypeName { get; set; }
    }

}

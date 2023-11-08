using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Commons.Constants
{
    public static class AutomobileTypeConstants
    {
        public static List<AutomobileTypeObject> Data = new List<AutomobileTypeObject>()
        {
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.NON_COMMERCIAL,  TypeName = "Xe không kinh doanh" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.BUS,             TypeName = "Xe buýt" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.COMMERCIAL,      TypeName = "Xe kinh doanh" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.DELIVERY_TRUCK,  TypeName = "Xe tải chở hàng" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.MINI_VAN,        TypeName = "Xe tải nhỏ" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.TAXI,            TypeName = "Xe taxi" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.CONTAINER,       TypeName = "Xe tải container" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.SPECIALIZED,     TypeName = "Xe chuyên chở đặc biệt" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.TRAINER,         TypeName = "Xe tập lái" },
            new AutomobileTypeObject() { TypeEnum = AutomobileTypeEnum.TRAINER_TRUCK,   TypeName = "Xe tải tập lái" },
        };
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

    public class AutomobileTypeObject
    {
        public AutomobileTypeEnum TypeEnum { get; set; }
        public string TypeName { get; set; }
    }
}

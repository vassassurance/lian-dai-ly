using LianAgentPortal.Commons.Constants;

namespace LianAgentPortal.Commons.Constants
{
    public static class MotorTypeConstants
    {
        public static List<MotorTypeObject> Data = new List<MotorTypeObject>()
        {
            new MotorTypeObject() { TypeEnum = MotorTypeEnum.UNDER,  TypeName = "Xe dưới 50cc" },
            new MotorTypeObject() { TypeEnum = MotorTypeEnum.OVER,  TypeName = "Xe trên 50cc" },
            new MotorTypeObject() { TypeEnum = MotorTypeEnum.TRICYCLE,  TypeName = "Xe ba bánh" },
            new MotorTypeObject() { TypeEnum = MotorTypeEnum.OTHER,  TypeName = "Xe loại khác/ chuyên dùng" },
        };
    }
    public enum MotorTypeEnum
    {
        UNDER = 100,
        OVER = 200,
        TRICYCLE = 300,
        OTHER = 400
    }

    public class MotorTypeObject
    {
        public MotorTypeEnum TypeEnum { get; set; }
        public string TypeName { get; set; }
    }
}

namespace LianAgentPortal.Commons.Constants
{
    public static class AutomobilesFullTypeConstants
    {
        public static List<AutomobilesFullTypeObject> Data = new List<AutomobilesFullTypeObject>()
        {
            new AutomobilesFullTypeObject() { DisplayName = "", AutomobileType = AutomobileTypeEnum.BUS, Attributes_Seat = "1", Attributes_Category = AutomobileTypeCategoryEnum.COMMERCIAL },
        };
    }

    public class AutomobilesFullTypeObject
    {
        public string DisplayName { get; set; }
        public AutomobileTypeEnum AutomobileType { get; set; }
        public string Attributes_Seat { get; set; }
        public AutomobileTypeCategoryEnum Attributes_Category { get; set; }
    }

}

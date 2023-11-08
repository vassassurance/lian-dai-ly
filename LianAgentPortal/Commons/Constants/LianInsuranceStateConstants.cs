namespace LianAgentPortal.Commons.Constants
{
    public class LianInsuranceStateConstants
    {

        public static List<LianInsuranceStateObject> Data = new List<LianInsuranceStateObject>()
        {
            new LianInsuranceStateObject() { TypeEnum = LianInsuranceStateEnum.SUCCEEDED,   TypeName = "Thành công",    TypeNameIcon = "<i class=\"fa fa-check-square text-success\" aria-hidden=\"true\" title=\"Thành công\"></i>" },
            new LianInsuranceStateObject() { TypeEnum = LianInsuranceStateEnum.PENDING,     TypeName = "Đang chờ",      TypeNameIcon = "<i class=\"fa fa-spinner text-primary\" aria-hidden=\"true\" title=\"Đang chờ\"></i>" },
            new LianInsuranceStateObject() { TypeEnum = LianInsuranceStateEnum.FAILED,      TypeName = "Lỗi/ Thất bại", TypeNameIcon = "<i class=\"fa fa-exclamation-triangle text-danger\" aria-hidden=\"true\" title=\"Lỗi/ Thất bại\"></i>" },
            new LianInsuranceStateObject() { TypeEnum = LianInsuranceStateEnum.CANCELED,    TypeName = "Đã hủy",        TypeNameIcon = "<i class=\"fa fa-times\" aria-hidden=\"true\" title=\"Đã hủy\"></i>" },
        };

    }

    public enum LianInsuranceStateEnum
    {
        SUCCEEDED = 100,
        PENDING = 200,
        FAILED = 300,
        CANCELED = 400
    }

    public class LianInsuranceStateObject
    {
        public LianInsuranceStateEnum TypeEnum { get; set; }
        public string TypeName { get; set; }
        public string TypeNameIcon { get; set; }
    }
}

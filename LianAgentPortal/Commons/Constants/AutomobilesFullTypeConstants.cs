namespace LianAgentPortal.Commons.Constants
{
    public static class AutomobilesFullTypeConstants
    {
        public static List<AutomobilesFullTypeObject> Data = new List<AutomobilesFullTypeObject>()
        {
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ KHÔNG KD VẬN TẢI & XE BUÝT", AutomobileType = AutomobileTypeEnum.NON_COMMERCIAL, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.NON_COMMERCIAL },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ KD VẬN TẢI", AutomobileType = AutomobileTypeEnum.COMMERCIAL, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.COMMERCIAL },

            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHỞ HÀNG, XE TẢI Dưới 3 tấn", AutomobileType = AutomobileTypeEnum.DELIVERY_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.UNDER_THREE_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHỞ HÀNG, XE TẢI Từ 3 đến 8 tấn", AutomobileType = AutomobileTypeEnum.DELIVERY_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.THREE_TO_EIGHT_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHỞ HÀNG, XE TẢI Trên 8 đến 15 tấn", AutomobileType = AutomobileTypeEnum.DELIVERY_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.EIGHT_TO_FIFTEEN_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHỞ HÀNG, XE TẢI Trên 15 tấn", AutomobileType = AutomobileTypeEnum.DELIVERY_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.OVER_FIFTEEN_TONS },

            new AutomobilesFullTypeObject() { DisplayName = "Vừa chở hàng và người (Mini van, Pickup) Không KD", AutomobileType = AutomobileTypeEnum.MINI_VAN, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.NON_COMMERCIAL },
            new AutomobilesFullTypeObject() { DisplayName = "Vừa chở hàng và người (Mini van, Pickup) Kinh doanh", AutomobileType = AutomobileTypeEnum.MINI_VAN, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.COMMERCIAL },

            new AutomobilesFullTypeObject() { DisplayName = "XE TAXI", AutomobileType = AutomobileTypeEnum.TAXI, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.COMMERCIAL },

            new AutomobilesFullTypeObject() { DisplayName = "XE ĐẦU KÉO Các loại", AutomobileType = AutomobileTypeEnum.CONTAINER, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.ALL },

            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Dưới 3 tấn", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.UNDER_THREE_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Từ 3 đến 8 tấn", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.THREE_TO_EIGHT_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Trên 8 đến 15 tấn", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.EIGHT_TO_FIFTEEN_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Trên 15 tấn", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.OVER_FIFTEEN_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Xe cứu thương", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.AMBULANCE },
            new AutomobilesFullTypeObject() { DisplayName = "XE Ô TÔ CHUYÊN DÙNG Xe chở tiền", AutomobileType = AutomobileTypeEnum.SPECIALIZED, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.MONEY_TRUCK },

            new AutomobilesFullTypeObject() { DisplayName = "XE TẬP LÁI (CHỞ NGƯỜI) 04 chỗ", AutomobileType = AutomobileTypeEnum.TRAINER, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.COMMERCIAL },

            new AutomobilesFullTypeObject() { DisplayName = "XE TẬP LÁI CHỞ HÀNG (XE TẢI) Dưới 3 tấn", AutomobileType = AutomobileTypeEnum.TRAINER_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.UNDER_THREE_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE TẬP LÁI CHỞ HÀNG (XE TẢI) Từ 3 đến 8 tấn", AutomobileType = AutomobileTypeEnum.TRAINER_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.THREE_TO_EIGHT_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE TẬP LÁI CHỞ HÀNG (XE TẢI) Trên 8 đến 15 tấn", AutomobileType = AutomobileTypeEnum.TRAINER_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.EIGHT_TO_FIFTEEN_TONS },
            new AutomobilesFullTypeObject() { DisplayName = "XE TẬP LÁI CHỞ HÀNG (XE TẢI) Trên 15 tấn", AutomobileType = AutomobileTypeEnum.TRAINER_TRUCK, Attributes_Seat = "", Attributes_Category = AutomobileTypeCategoryEnum.OVER_FIFTEEN_TONS },

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

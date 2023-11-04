using LianAgentPortal.Commons.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LianAgentPortal.Models.ViewModels.BaseInsurance
{
    public class TimeCoverageObject
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TimeCoverageUnitEnum Unit { get; set; }
        public int Value { get; set; }
    }

    public class TimeCoverageObjectString
    {
        public string Unit { get; set; }
        public int Value { get; set; }
    }
}

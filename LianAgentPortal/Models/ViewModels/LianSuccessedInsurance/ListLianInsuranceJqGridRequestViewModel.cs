using LianAgentPortal.Models.ViewModels.JqGrid;

namespace LianAgentPortal.Models.ViewModels.LianInsurance
{
    public class ListSuccessedInsuranceJqGridRequestViewModel : BaseJqgridRequestViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

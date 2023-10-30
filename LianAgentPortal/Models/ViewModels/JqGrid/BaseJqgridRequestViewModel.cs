namespace LianAgentPortal.Models.ViewModels.JqGrid
{
    public class BaseJqgridRequestViewModel
    {
        public bool _search { get; set; }
        public int page { get; set; }
        public int rows { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }
        public string id { get; set; }
        public string oper { get; set; }
        public string edit { get; set; }
        public string add { get; set; }
        public string del { get; set; }
        public string filters { get; set; }
        public string searchField { get; set; }
        public string searchString { get; set; }
        public string searchOper { get; set; }
    }
}

namespace LianAgentPortal.Models.ViewModels.JqGrid
{
    public class JqgridTreeViewModel<Tkey>
    {
        public Tkey level { get; set; }
        public Tkey parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
    }
}

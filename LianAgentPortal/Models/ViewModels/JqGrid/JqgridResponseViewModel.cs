using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LianAgentPortal.Models.ViewModels.JqGrid
{
    public class JqgridResponseViewModel<T>
    {
        public int pageSize { get; set; }
        public int page { get; set; }
        public int total { get; set; }
        public int records { get; set; }
        public List<T> rows { get; set; }
        public T userdata { get; set; }

    }
}

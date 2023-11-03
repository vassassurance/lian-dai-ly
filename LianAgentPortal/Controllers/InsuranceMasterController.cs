using AutoMapper;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.Account;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.JqGrid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceMasterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        public InsuranceMasterController(ApplicationDbContext db, IMapper mapper) 
        { 
            _db = db;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetListInsuranceMasterJqgrid(BaseJqgridRequestViewModel gridRequest)
        {
            List<InsuranceMaster> data = _db.InsuranceMasters.ToList();
            JqgridResponseViewModel<InsuranceMasterViewModel> result = new JqgridResponseViewModel<InsuranceMasterViewModel>();
            IQueryable<InsuranceMasterViewModel> source = _mapper.Map<List<InsuranceMasterViewModel>>(data).AsQueryable();

            int totalrecord = source.Count();
            int page = totalrecord / gridRequest.rows + (totalrecord % gridRequest.rows > 0 ? 1 : 0);
            int totalPage = gridRequest.rows > 1 ? page : 1;
            result.page = gridRequest.rows > 1 ? gridRequest.page : 1;
            result.pageSize = gridRequest.rows;
            result.total = totalPage;
            result.records = totalrecord;
            result.rows = source.OrderBy(gridRequest.sidx, gridRequest.sord)
                .Skip((gridRequest.page - 1) * gridRequest.rows)
                .Take(gridRequest.rows)
                .ToList();

            return Ok(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateInsuranceMasterViewModel model)
        {
            return View();
        }

    }
}

using AutoMapper;
using Hangfire;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.InsuranceAutomobileDetail;
using LianAgentPortal.Models.ViewModels.JqGrid;
using LianAgentPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceAutomobileDetailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly IHangeFireJobService _hangeFireJobService;
        public InsuranceAutomobileDetailController(IMapper mapper, ApplicationDbContext db, IHangeFireJobService hangeFireJobService) 
        {
            _mapper = mapper;
            _db = db;
            _hangeFireJobService = hangeFireJobService;
        }

        public IActionResult Index(long id)
        {
            var insuranceMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceMaster == null) return RedirectToAction("Index", "InsuranceMaster");
            
            InsuranceMasterViewModel model = _mapper.Map<InsuranceMasterViewModel>(insuranceMaster);
            return View(model);
        }

        public IActionResult GetListInsuranceAutomobileDetailJqgrid(ListInsuranceAutomobileDetailJqGridRequestViewModel gridRequest)
        {
            List<InsuranceAutomobileDetail> data = _db.InsuranceAutomobileDetails.Where(item => item.InsuranceMasterId == gridRequest.InsuranceMasterId).ToList();
            JqgridResponseViewModel<InsuranceAutomobileDetailViewModel> result = new JqgridResponseViewModel<InsuranceAutomobileDetailViewModel>();
            IQueryable<InsuranceAutomobileDetailViewModel> source = _mapper.Map<List<InsuranceAutomobileDetailViewModel>>(data).AsQueryable();

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

        [HttpPost]
        public IActionResult CalculatePremium(long id)
        {
            var insuranceMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceMaster == null) return RedirectToAction("Index", "InsuranceMaster");

            List<InsuranceAutomobileDetail> details = _db.InsuranceAutomobileDetails.Where(item =>
                (item.Status == InsuranceDetailStatusEnum.NEW || item.Status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR)
                && item.InsuranceMasterId == id
            ).ToList();

            
            for (int i = 0; i < details.Count; i++)
            {
                details[i].Status = InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS;
            }
            _db.SaveChanges();

            _hangeFireJobService.MakeJobCalculatePremiumAutomobileInsurances(id, details.Select(item => item.Id).ToList(), User.Identity.Name);
           
            return RedirectToAction("index", new { id = id });
        }


        [HttpPost]
        public IActionResult BuyInsurance(long id)
        {
            var insuranceMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceMaster == null) return RedirectToAction("Index", "InsuranceMaster");

            List<InsuranceAutomobileDetail> details = _db.InsuranceAutomobileDetails.Where(item =>
                (item.Status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS)
                && item.InsuranceMasterId == id
            ).ToList();


            for (int i = 0; i < details.Count; i++)
            {
                details[i].Status = InsuranceDetailStatusEnum.SYNC_INPROGRESS;
            }
            _db.SaveChanges();

            _hangeFireJobService.MakeJobBuyMotorInsurances(id, details.Select(item => item.Id).ToList(), User.Identity.Name);

            return RedirectToAction("index", new { id = id });
        }

    }
}

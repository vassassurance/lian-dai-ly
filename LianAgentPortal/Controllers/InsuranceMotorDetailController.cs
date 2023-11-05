using AutoMapper;
using Hangfire;
using LianAgentPortal.Commons.Enums;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;
using LianAgentPortal.Models.ViewModels.JqGrid;
using LianAgentPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceMotorDetailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly IHangeFireJobService _hangeFireJobService;
        public InsuranceMotorDetailController(IMapper mapper, ApplicationDbContext db, IHangeFireJobService hangeFireJobService) 
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

        public IActionResult GetListInsuranceMotorDetailJqgrid(ListInsuranceMotorDetailJqGridRequestViewModel gridRequest)
        {
            List<InsuranceMotorDetail> data = _db.InsuranceMotorDetails.Where(item => item.InsuranceMasterId == gridRequest.InsuranceMasterId).ToList();
            JqgridResponseViewModel<InsuranceMotorDetailViewModel> result = new JqgridResponseViewModel<InsuranceMotorDetailViewModel>();
            IQueryable<InsuranceMotorDetailViewModel> source = _mapper.Map<List<InsuranceMotorDetailViewModel>>(data).AsQueryable();

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

            List<InsuranceMotorDetail> details = _db.InsuranceMotorDetails.Where(item =>
                (item.Status == Commons.Enums.InsuranceDetailStatusEnum.NEW || item.Status == InsuranceDetailStatusEnum.CALCULATE_PREMIUM_ERROR)
                && item.InsuranceMasterId == id
            ).ToList();

            
            for (int i = 0; i < details.Count; i++)
            {
                details[i].Status = Commons.Enums.InsuranceDetailStatusEnum.CALCULATE_PREMIUM_INPROGRESS;
            }
            _db.SaveChanges();

            _hangeFireJobService.MakeJobCalculatePremiumMotorInsurances(id, details.Select(item => item.Id).ToList(), User.Identity.Name);
           
            return RedirectToAction("index", new { id = id });
        }


        [HttpPost]
        public IActionResult BuyInsurance(long id)
        {
            var insuranceMaster = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceMaster == null) return RedirectToAction("Index", "InsuranceMaster");

            List<InsuranceMotorDetail> details = _db.InsuranceMotorDetails.Where(item =>
                (item.Status == Commons.Enums.InsuranceDetailStatusEnum.CALCULATE_PREMIUM_SUCCESS)
                && item.InsuranceMasterId == id
            ).ToList();


            for (int i = 0; i < details.Count; i++)
            {
                details[i].Status = Commons.Enums.InsuranceDetailStatusEnum.SYNC_INPROGRESS;
            }
            _db.SaveChanges();

            _hangeFireJobService.MakeJobBuyMotorInsurances(id, details.Select(item => item.Id).ToList(), User.Identity.Name);

            return RedirectToAction("index", new { id = id });
        }

    }
}

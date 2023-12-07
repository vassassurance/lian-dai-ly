using AutoMapper;
using DocumentFormat.OpenXml.Office.CustomUI;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.InsuranceMotorDetail;
using LianAgentPortal.Models.ViewModels.JqGrid;
using LianAgentPortal.Models.ViewModels.LianInsurance;
using LianAgentPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class LianSucceededInsuranceController : BaseController
    {
        private readonly ILianApiService _lianApiService;
        private readonly IMapper _mapper;
        public LianSucceededInsuranceController(ILianApiService lianApiService, ApplicationDbContext db, IMapper mapper) : base(db)
        {
            _lianApiService = lianApiService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetListLianInsuranceJqgrid(ListLianInsuranceJqGridRequestViewModel gridRequest)
        {
            LianInsuranceSearchResponseViewModel searchResult = _lianApiService.SearchLianInsurance(gridRequest, base.CurrentUserApiKey, CurrentUser.AccountId);

            JqgridResponseViewModel<LianInsuranceSearchResponseDataViewModel> result = new JqgridResponseViewModel<LianInsuranceSearchResponseDataViewModel>();
            IQueryable<LianInsuranceSearchResponseDataViewModel> source = _mapper.Map<List<LianInsuranceSearchResponseDataViewModel>>(searchResult.Data).AsQueryable();
            
            int totalrecord = (gridRequest.page + 1) * gridRequest.rows;
            int page = totalrecord / gridRequest.rows + (totalrecord % gridRequest.rows > 0 ? 1 : 0);
            int totalPage = gridRequest.rows > 1 ? page : 1;
            result.page = gridRequest.rows > 1 ? gridRequest.page : 1;
            result.pageSize = gridRequest.rows;
            result.total = totalPage;
            result.records = totalrecord;
            result.rows = source.ToList();

            return Ok(result);
        }

    }
}

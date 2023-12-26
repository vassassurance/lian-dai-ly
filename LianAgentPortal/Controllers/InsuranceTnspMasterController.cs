using AutoMapper;
using ClosedXML.Excel;
using LianAgentPortal.Commons;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.InsuranceTnspMaster;
using LianAgentPortal.Models.ViewModels.JqGrid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceTnspMasterController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public InsuranceTnspMasterController(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(db)
        {
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateInsuranceTnspMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                long insertedId = InsertUploadToDatabase(model);

                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", "InsuranceTnspDetail", new { id = insertedId });
                }


            }
            return View();
        }

        private long InsertUploadToDatabase(CreateInsuranceTnspMasterViewModel model)
        {
            using (var stream = new MemoryStream())
            {
                model.ReportFile.CopyTo(stream);
                var workbook = new XLWorkbook(stream);
                var mainSheet = workbook.Worksheet("Sheet1");

                InsuranceTnspMaster insuranceTnspMaster = new InsuranceTnspMaster()
                {
                    DateCreate = DateTime.Now,
                    UserCreate = User.Identity.Name,
                    FileName = model.ReportFile.FileName,
                    TotalInsuranceAmount = 0,
                    TotalIssuedRows = 0,
                    TotalPremium = 0,
                    TotalRows = 0,
                    IsDeleted = false,
                };
                _db.InsuranceTnspMasters.Add(insuranceTnspMaster);
                _db.SaveChanges();

                List<InsuranceTnspDetail> details = GetInsuranceTnspDetailFromExcel(mainSheet, insuranceTnspMaster.Id);
                _db.InsuranceTnspDetails.AddRange(details);

                insuranceTnspMaster.TotalRows = details.Count;
                insuranceTnspMaster.TotalInsuranceAmount = details.Sum(item => item.InsuranceAmount);
                insuranceTnspMaster.TotalPremium = details.Sum(item => item.Premium);

                if (ModelState.IsValid
                    && insuranceTnspMaster.TotalRows > 0)
                {
                    insuranceTnspMaster.FilePath = SaveFileToDisk(model);
                    _db.SaveChanges();
                    return insuranceTnspMaster.Id;
                }
                else
                {
                    insuranceTnspMaster.IsDeleted = true;
                    _db.SaveChanges();
                }
                return 0;
            }
        }

        private List<InsuranceTnspDetail> GetInsuranceTnspDetailFromExcel(IXLWorksheet mainSheet, long masterId)
        {
            var userRequest = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == User.Identity.Name);
            if (userRequest == null || userRequest.LianAgent == null) throw new KeyNotFoundException();

            int lastRowNumber = mainSheet.LastRowUsed().RowNumber();
            List<InsuranceTnspDetail> details = new List<InsuranceTnspDetail>();

            for (int i = 2; i <= lastRowNumber; i++)
            {
                try
                {
                    var detailItem = new InsuranceTnspDetail()
                    {
                        InsuranceTnspMasterId = masterId,
                        InsuranceAmount = 10000000,
                        Premium = 50000,
                        OrderId = Functions.GetCellValue(mainSheet.Row(i).Cell(1).Value.ToString()),
                        CustomerName = Functions.GetCellValue(mainSheet.Row(i).Cell(2).Value.ToString()),
                        IdentityNumber = Functions.GetCellValue(mainSheet.Row(i).Cell(3).Value.ToString()),
                        FromDate = mainSheet.Row(i).Cell(4).GetDateTime(),
                        ToDate = mainSheet.Row(i).Cell(5).GetDateTime(),
                        Status = InsuranceOtherStatusEnum.NEW,
                        InsuranceNo = "",
                        CertificateDigitalLink = ""
                    };
                    details.Add(detailItem);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return details;
        }


        private string SaveFileToDisk(CreateInsuranceTnspMasterViewModel model)
        {
            if (model.ReportFile != null)
            {
                string folder = "uploaded-files/" + Guid.NewGuid().ToString();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                System.IO.Directory.CreateDirectory(uploadsFolder);
                string filePath = Path.Combine(uploadsFolder, model.ReportFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ReportFile.CopyTo(fileStream);
                }
                return "/" + folder + "/" + model.ReportFile.FileName;
            }
            return null;
        }

        public IActionResult GetListInsuranceTnspMasterJqgrid(BaseJqgridRequestViewModel gridRequest)
        {
            List<InsuranceTnspMaster> data = _db.InsuranceTnspMasters.Where(item =>
                IsCurrentUserHasRoleAdmin
                && !item.IsDeleted
            ).ToList();
            JqgridResponseViewModel<InsuranceTnspMasterViewModel> result = new JqgridResponseViewModel<InsuranceTnspMasterViewModel>();
            IQueryable<InsuranceTnspMasterViewModel> source = _mapper.Map<List<InsuranceTnspMasterViewModel>>(data).AsQueryable();

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

    }
}

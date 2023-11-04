using AutoMapper;
using ClosedXML.Excel;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.Account;
using LianAgentPortal.Models.ViewModels.BaseInsurance;
using LianAgentPortal.Models.ViewModels.InsuranceMaster;
using LianAgentPortal.Models.ViewModels.JqGrid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceMasterController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        public InsuranceMasterController(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment) 
        {
            _webHostEnvironment = webHostEnvironment;
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
            if (ModelState.IsValid)
            {
                long insertedId = InsertUploadToDatabase(model);
                return RedirectToAction("ViewDetail", new { id = insertedId });
            }
            return View();
        }

        public ActionResult ViewDetail(int id) 
        {
            var master = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id && item.UserCreate == User.Identity.Name);
            if (master == null) return RedirectToAction("index");

            if (master.Type == Commons.Enums.InsuranceTypeEnum.MOTORBIKE)
            {
                return RedirectToAction("Index", "InsuranceMotorDetail", new { id = id });
            }
            else if (master.Type == Commons.Enums.InsuranceTypeEnum.FAMILY_BREADWINNER)
            {
                return RedirectToAction("Index", "InsuranceFamilyBreadwinnerDetail", new { id = id });
            }
            else if (master.Type == Commons.Enums.InsuranceTypeEnum.PERSONAL_ACCIDENT)
            {
                return RedirectToAction("Index", "InsurancePersonalAccidentDetail", new { id = id });
            }

            return RedirectToAction("Index");
        }


        private long InsertUploadToDatabase(CreateInsuranceMasterViewModel model)
        {
            using (var stream = new MemoryStream())
            {
                model.ReportFile.CopyTo(stream);
                var workbook = new XLWorkbook(stream);
                var mainSheet = workbook.Worksheet("Sheet1");

                InsuranceMaster insuranceMaster = new InsuranceMaster()
                {
                    DateCreate = DateTime.Now,
                    UserCreate = User.Identity.Name,
                    FileName = model.ReportFile.FileName,
                    FilePath = "",
                    Type = model.Type,
                    TotalInsuranceAmount = 0,
                    TotalIssuedRows = 0,
                    TotalPremium = 0,
                    TotalRows = 0,
                };
                _db.InsuranceMasters.Add(insuranceMaster);
                _db.SaveChanges();

                if (model.Type == Commons.Enums.InsuranceTypeEnum.MOTORBIKE)
                {
                    List<InsuranceMotorDetail> details = GetInsuranceMotorDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsuranceMotorDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }
                else if (model.Type == Commons.Enums.InsuranceTypeEnum.FAMILY_BREADWINNER)
                {
                    List<InsuranceFamilyBreadwinnerDetail> details = GetInsuranceFamilyBreadwinnerDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsuranceFamilyBreadwinnerDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }
                else if (model.Type == Commons.Enums.InsuranceTypeEnum.PERSONAL_ACCIDENT)
                {
                    List<InsurancePersonalAccidentDetail> details = GetInsurancePersonalAccidentDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsurancePersonalAccidentDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }

                insuranceMaster.FilePath = SaveFileToDisk(model);
                _db.SaveChanges();
                return insuranceMaster.Id;
            }
        }

        private string SaveFileToDisk(CreateInsuranceMasterViewModel model)
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

        private string GetNumberCellValue(string cachedValue)
        {
            if (cachedValue == null || cachedValue.Length == 0)
            {
                return "0";
            }
            return cachedValue;
        }

        private Commons.Enums.MotorTypeEnum GetMotorTypeFromString(string type)
        {
            if (type.ToLower().Trim() == "dưới 50cc") return Commons.Enums.MotorTypeEnum.UNDER;
            if (type.ToLower().Trim() == "trên 50cc") return Commons.Enums.MotorTypeEnum.OVER;
            if (type.ToLower().Trim() == "ba bánh") return Commons.Enums.MotorTypeEnum.TRICYCLE;
            if (type.ToLower().Trim() == "khác") return Commons.Enums.MotorTypeEnum.OTHER;
            throw new InvalidDataException(type);
        }

        private List<InsuranceMotorDetail> GetInsuranceMotorDetailFromExcel(IXLWorksheet mainSheet, CreateInsuranceMasterViewModel model, long masterId)
        {
            var userRequest = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == User.Identity.Name);
            if (userRequest == null || userRequest.LianAgent == null) throw new KeyNotFoundException();

            int lastRowNumber = mainSheet.LastRowUsed().RowNumber();
            List<InsuranceMotorDetail> details = new List<InsuranceMotorDetail>();
            TimeCoverageObject defaultTimeCoverage = new TimeCoverageObject()
            {
                Unit = Commons.Enums.TimeCoverageUnitEnum.YEAR,
                Value = 1
            };
            for (int i = 2; i <= lastRowNumber; i++)
            {
                try
                {
                    details.Add(new InsuranceMotorDetail()
                    {
                        InsuranceMasterId = masterId,
                        Type = model.Type,
                        Amount = null,
                        LicensePlates = GetNumberCellValue(mainSheet.Row(i).Cell(1).Value.ToString()),
                        MotorType = GetMotorTypeFromString(GetNumberCellValue(mainSheet.Row(i).Cell(2).Value.ToString())),
                        ChassisNumber = GetNumberCellValue(mainSheet.Row(i).Cell(3).Value.ToString()),
                        MachineNumber = GetNumberCellValue(mainSheet.Row(i).Cell(4).Value.ToString()),
                        Fullname = GetNumberCellValue(mainSheet.Row(i).Cell(5).Value.ToString()),
                        Birhtday = DateTime.ParseExact(GetNumberCellValue(mainSheet.Row(i).Cell(6).Value.ToString().Split(' ')[0]), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Phone = GetNumberCellValue(mainSheet.Row(i).Cell(7).Value.ToString()),
                        IdentityNumber = GetNumberCellValue(mainSheet.Row(i).Cell(8).Value.ToString()),
                        PassengerInsurance = GetNumberCellValue(mainSheet.Row(i).Cell(9).Value.ToString()) == "1",
                        EffectiveDate = DateTime.ParseExact(GetNumberCellValue(mainSheet.Row(i).Cell(10).Value.ToString().Split(' ')[0]), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Status = Commons.Enums.InsuranceDetailStatusEnum.NEW,
                        AgentPhone = userRequest.LianAgent.RegistedPhone,
                        Language = "vi",
                        TimeCoverage = Newtonsoft.Json.JsonConvert.SerializeObject(defaultTimeCoverage),
                        PartnerTransaction = Guid.NewGuid().ToString().Replace("-", ""),
                    });
                }
                catch (Exception ex)
                {

                }

            }
            return details;
        }

        private List<InsuranceFamilyBreadwinnerDetail> GetInsuranceFamilyBreadwinnerDetailFromExcel(IXLWorksheet mainSheet, CreateInsuranceMasterViewModel model, long reportId)
        {
            return new List<InsuranceFamilyBreadwinnerDetail>();
        }

        private List<InsurancePersonalAccidentDetail> GetInsurancePersonalAccidentDetailFromExcel(IXLWorksheet mainSheet, CreateInsuranceMasterViewModel model, long reportId)
        {
            return new List<InsurancePersonalAccidentDetail>();
        }


    }
}

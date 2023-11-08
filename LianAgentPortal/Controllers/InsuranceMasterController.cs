using AutoMapper;
using ClosedXML.Excel;
using LianAgentPortal.Commons.Constants;
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
    public class InsuranceMasterController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public InsuranceMasterController(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(db)
        {
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetListInsuranceMasterJqgrid(BaseJqgridRequestViewModel gridRequest)
        {
            List<InsuranceMaster> data = _db.InsuranceMasters.Where(item => item.UserCreate == User.Identity.Name || IsCurrentUserHasRoleAdmin).ToList();
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
            var master = _db.InsuranceMasters.FirstOrDefault(item => item.Id == id && (item.UserCreate == User.Identity.Name || IsCurrentUserHasRoleAdmin));
            if (master == null) return RedirectToAction("index");


            if (master.Type == InsuranceTypeEnum.AUTOMOBILES)
            {
                return RedirectToAction("Index", "InsuranceAutomobileDetail", new { id = id });
            }
            else if(master.Type == InsuranceTypeEnum.MOTORBIKE)
            {
                return RedirectToAction("Index", "InsuranceMotorDetail", new { id = id });
            }
            else if (master.Type == InsuranceTypeEnum.FAMILY_BREADWINNER)
            {
                return RedirectToAction("Index", "InsuranceFamilyBreadwinnerDetail", new { id = id });
            }
            else if (master.Type == InsuranceTypeEnum.PERSONAL_ACCIDENT)
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

                if (model.Type == InsuranceTypeEnum.MOTORBIKE)
                {
                    List<InsuranceMotorDetail> details = GetInsuranceMotorDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsuranceMotorDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }
                else if (model.Type == InsuranceTypeEnum.FAMILY_BREADWINNER)
                {
                    List<InsuranceFamilyBreadwinnerDetail> details = GetInsuranceFamilyBreadwinnerDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsuranceFamilyBreadwinnerDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }
                else if (model.Type == InsuranceTypeEnum.PERSONAL_ACCIDENT)
                {
                    List<InsurancePersonalAccidentDetail> details = GetInsurancePersonalAccidentDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsurancePersonalAccidentDetails.AddRange(details);
                    insuranceMaster.TotalRows = details.Count;
                }
                else if (model.Type == InsuranceTypeEnum.AUTOMOBILES)
                {
                    List<InsuranceAutomobileDetail> details = GetInsuranceAutomobileDetailFromExcel(mainSheet, model, insuranceMaster.Id);
                    _db.InsuranceAutomobileDetails.AddRange(details);
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

        private MotorTypeEnum GetMotorTypeFromString(string type)
        {
            if (type.ToLower().Trim() == "dưới 50cc") return MotorTypeEnum.UNDER;
            if (type.ToLower().Trim() == "trên 50cc") return MotorTypeEnum.OVER;
            if (type.ToLower().Trim() == "ba bánh") return MotorTypeEnum.TRICYCLE;
            if (type.ToLower().Trim() == "khác") return MotorTypeEnum.OTHER;
            throw new InvalidDataException(type);
        }

        private AutomobileTypeEnum GetAutomobileTypeFromString(string type)
        {
            var result = AutomobileTypeConstants.Data.FirstOrDefault(item => item.TypeName.ToLower() == type.ToLower().Trim());
            if (result != null)
            {
                return result.TypeEnum;
            }

            throw new InvalidDataException(type);
        }
        private AutomobileTypeCategoryEnum GetAutomobileTypeCategoryFromString(string type)
        {
            var result = AutomobileTypeCategoryConstants.Data.FirstOrDefault(item => item.TypeName.ToLower().Trim() == type.ToLower().Trim());
            if (result != null)
            {
                return result.TypeEnum;
            }

            throw new InvalidDataException(type);
        }
        
        private GenderEnum GetGenderFromString(string gender)
        {
            if (gender == "1"
                || gender.ToLower().Trim() == "nam")
            {
                return GenderEnum.MALE;
            }
            return GenderEnum.FEMALE;
        }

        private List<InsuranceAutomobileDetail> GetInsuranceAutomobileDetailFromExcel(IXLWorksheet mainSheet, CreateInsuranceMasterViewModel model, long masterId)
        {
            var userRequest = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == User.Identity.Name);
            if (userRequest == null || userRequest.LianAgent == null) throw new KeyNotFoundException();

            int lastRowNumber = mainSheet.LastRowUsed().RowNumber();
            List<InsuranceAutomobileDetail> details = new List<InsuranceAutomobileDetail>();
            string defaultTimeCoverage = Newtonsoft.Json.JsonConvert.SerializeObject(new TimeCoverageObject()
            {
                Unit = TimeCoverageUnitEnum.YEAR,
                Value = 1
            });
            for (int i = 2; i <= lastRowNumber; i++)
            {
                try
                {
                    int passengerCount = 0;
                    long passengerFee = 0;
                    if (!int.TryParse(GetNumberCellValue(mainSheet.Row(i).Cell(8).Value.ToString()), out passengerCount))
                    {
                        passengerCount = 0;
                        passengerFee = 10000;
                    }

                    details.Add(new InsuranceAutomobileDetail()
                    {
                        InsuranceMasterId = masterId,
                        Type = model.Type,
                        Amount = null,
                        LicensePlates = GetNumberCellValue(mainSheet.Row(i).Cell(1).Value.ToString()),
                        AutomobilesType = GetAutomobileTypeFromString(GetNumberCellValue(mainSheet.Row(i).Cell(2).Value.ToString())),
                        Attributes_Seat = GetNumberCellValue(mainSheet.Row(i).Cell(3).Value.ToString()),
                        Attributes_Category = GetAutomobileTypeCategoryFromString(GetNumberCellValue(mainSheet.Row(i).Cell(4).Value.ToString())),
                        Fullname = GetNumberCellValue(mainSheet.Row(i).Cell(5).Value.ToString()),
                        ChassisNumber = GetNumberCellValue(mainSheet.Row(i).Cell(6).Value.ToString()),
                        MachineNumber = GetNumberCellValue(mainSheet.Row(i).Cell(7).Value.ToString()),
                        PassengerFee = passengerFee,
                        PassengerCount = passengerCount,
                        LiabilityInsuranceFee = 0,
                        Phone = GetNumberCellValue(mainSheet.Row(i).Cell(9).Value.ToString()),
                        Email = GetNumberCellValue(mainSheet.Row(i).Cell(10).Value.ToString()),
                        Gender = GetGenderFromString(GetNumberCellValue(mainSheet.Row(i).Cell(11).Value.ToString())),
                        Description = null,
                        EffectiveDate = DateTime.ParseExact(GetNumberCellValue(mainSheet.Row(i).Cell(12).Value.ToString().Split(' ')[0]), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Status = InsuranceDetailStatusEnum.NEW,
                        Language = "vi",
                        TimeCoverage = defaultTimeCoverage,
                        PartnerTransaction = Guid.NewGuid().ToString().Replace("-", ""),
                    });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return details;
        }

        private List<InsuranceMotorDetail> GetInsuranceMotorDetailFromExcel(IXLWorksheet mainSheet, CreateInsuranceMasterViewModel model, long masterId)
        {
            var userRequest = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == User.Identity.Name);
            if (userRequest == null || userRequest.LianAgent == null) throw new KeyNotFoundException();

            int lastRowNumber = mainSheet.LastRowUsed().RowNumber();
            List<InsuranceMotorDetail> details = new List<InsuranceMotorDetail>();
            TimeCoverageObject defaultTimeCoverage = new TimeCoverageObject()
            {
                Unit = TimeCoverageUnitEnum.YEAR,
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
                        Status = InsuranceDetailStatusEnum.NEW,
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

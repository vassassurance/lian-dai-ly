using AutoMapper;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.InsuranceTnspDetail;
using LianAgentPortal.Models.ViewModels.InsuranceTnspMaster;
using LianAgentPortal.Models.ViewModels.JqGrid;
using LianAgentPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace LianAgentPortal.Controllers
{
    [Authorize]
    public class InsuranceTnspDetailController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IHangeFireJobService _hangeFireJobService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InsuranceTnspDetailController(IMapper mapper, ApplicationDbContext db, IHangeFireJobService hangeFireJobService, IWebHostEnvironment webHostEnvironment) : base(db)
        {
            _mapper = mapper;
            _hangeFireJobService = hangeFireJobService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(long id)
        {
            var insuranceTnspMaster = _db.InsuranceTnspMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceTnspMaster == null) return RedirectToAction("Index", "InsuranceTnspMaster");

            InsuranceTnspMasterViewModel model = _mapper.Map<InsuranceTnspMasterViewModel>(insuranceTnspMaster);

            return View(model);
        }

        public IActionResult GetListInsuranceTnspDetailJqgrid(ListInsuranceTnspDetailJqGridRequestViewModel gridRequest)
        {
            List<InsuranceTnspDetail> data = _db.InsuranceTnspDetails.Where(item => item.InsuranceTnspMasterId == gridRequest.InsuranceTnspMasterId).ToList();
            JqgridResponseViewModel<InsuranceTnspDetailViewModel> result = new JqgridResponseViewModel<InsuranceTnspDetailViewModel>();
            IQueryable<InsuranceTnspDetailViewModel> source = _mapper.Map<List<InsuranceTnspDetailViewModel>>(data).AsQueryable();

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
        public IActionResult DownloadCertificateZip(long id)
        {
            var insuranceTnspMaster = _db.InsuranceTnspMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceTnspMaster == null) return RedirectToAction("Index", "InsuranceTnspMaster");

            string webRootPath = _webHostEnvironment.WebRootPath;

            string startPath = Path.Combine(webRootPath, CertificateFolders.Folder020502Tnsp + insuranceTnspMaster.Id);
            string zipPath = startPath + ".zip";

            FileInfo file = new FileInfo(zipPath);
            if (file.Exists)
            {
                file.Delete();
            }

            ZipFile.CreateFromDirectory(startPath, zipPath);

            byte[] fileBytes = System.IO.File.ReadAllBytes(zipPath);

            file = new FileInfo(zipPath);
            if (file.Exists)
            {
                file.Delete();
            }

            return File(fileBytes, "application/force-download", "data.zip");
        }


        [HttpPost]
        public IActionResult GenerateCertificate(long id)
        {
            var insuranceTnspMaster = _db.InsuranceTnspMasters.FirstOrDefault(item => item.Id == id);
            if (insuranceTnspMaster == null) return RedirectToAction("Index", "InsuranceTnspMaster");

            List<InsuranceTnspDetail> details = _db.InsuranceTnspDetails.Where(item =>
                (item.Status == InsuranceOtherStatusEnum.NEW
                    || item.Status == InsuranceOtherStatusEnum.GENCER_ERROR
                )
                && item.InsuranceTnspMasterId == id
            ).ToList();


            for (int i = 0; i < details.Count; i++)
            {
                details[i].Status = InsuranceOtherStatusEnum.GENCER_INPROGRESS;
            }
            _db.SaveChanges();

            _hangeFireJobService.MakeJobGenCerTnsp(id, details.Select(item => item.Id).ToList());


            return RedirectToAction("index", new { id = id });
        }

    }
}

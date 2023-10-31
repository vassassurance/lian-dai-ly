using AutoMapper;
using Google.Authenticator;
using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.DbModels;
using LianAgentPortal.Models.ViewModels.JqGrid;
using LianAgentPortal.Models.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace LianAgentPortal.Controllers
{
    [Authorize(Roles = AuthenticatorConstants.ADMIN_ROLE)]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<LianUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(
            ApplicationDbContext db,
            UserManager<LianUser> userManager,
            IMapper mapper,
            IConfiguration configuration)
        {
            this._db = db;
            this._userManager = userManager;
            this._mapper = mapper;
            this._configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetListUserJqgridAsync(BaseJqgridRequestViewModel gridRequest)
        {

            List<LianUser> data = _userManager.Users.ToList();
            JqgridResponseViewModel<LianUserViewModel> result = new JqgridResponseViewModel<LianUserViewModel>();
            IQueryable<LianUserViewModel> source = _mapper.Map<List<LianUserViewModel>>(data).AsQueryable();

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

            for (int i = 0; i < result.rows.Count; i++)
            {
                var userFromDb = data.FirstOrDefault(item => item.Id == result.rows[i].Id);
                if (userFromDb != null)
                {
                    result.rows[i].IsAdmin = await _userManager.IsInRoleAsync(userFromDb, AuthenticatorConstants.ADMIN_ROLE);
                }
            }

            return Ok(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLianUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                LianUser dbUser = new LianUser()
                {
                    Email = model.UserName,
                    UserName = model.UserName,
                    GoogleAuthenticatorSecretCode = Guid.NewGuid().ToString().Split("-")[0],
                    IsActivated = true,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    CreateDate = DateTime.Now
                };
                var createTask = await _userManager.CreateAsync(dbUser, model.Password);
                if (createTask.Succeeded)
                {
                    if (model.IsAdmin)
                    {
                        await _userManager.AddToRoleAsync(dbUser, AuthenticatorConstants.ADMIN_ROLE);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(dbUser, AuthenticatorConstants.ADMIN_ROLE);
                    }
                }
                else
                {
                    ModelState.AddModelError("", createTask.Errors.First().Description);
                }

            }
            if (ModelState.IsValid)
            {
                TempData["InfoMessage"] = "Tạo mới thành công";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                EditLianUserViewModel model = new EditLianUserViewModel();
                LianUser dbUser = await _userManager.FindByIdAsync(id);
                IList<string> roles = await _userManager.GetRolesAsync(dbUser);
                if (dbUser != null && roles != null)
                {
                    ViewBag.Username = dbUser.UserName;
                    return View(new EditLianUserViewModel()
                    {
                        Id = dbUser.Id,
                        IsActivated = dbUser.IsActivated,
                        IsAdmin = await _userManager.IsInRoleAsync(dbUser, AuthenticatorConstants.ADMIN_ROLE)
                    });
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditLianUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                LianUser dbUser = await _userManager.FindByIdAsync(model.Id);
                if (dbUser != null)
                {
                    ViewBag.Username = dbUser.UserName;
                    if ((dbUser.UserName == "admin789bdev" || dbUser.UserName == "admin789b")
                        && !model.IsActivated)
                    {
                        ModelState.AddModelError("", "Bạn không thể hủy user này");
                        return View(model);
                    }

                    dbUser.IsActivated = model.IsActivated;
                    dbUser.UpdateDate = DateTime.Now;

                    if (model.Password != null && model.Password.Length > 0)
                    {
                        var taskRemovePassword = await _userManager.RemovePasswordAsync(dbUser);
                        if (taskRemovePassword.Succeeded)
                        {
                            var taskAddPassord = await _userManager.AddPasswordAsync(dbUser, model.Password);
                            if (!taskAddPassord.Succeeded)
                            {
                                ModelState.AddModelError("", taskAddPassord.Errors.First().Description);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", taskRemovePassword.Errors.First().Description);
                        }
                    }

                    var taskUpdate = await _userManager.UpdateAsync(dbUser);
                    if (!taskUpdate.Succeeded)
                    {
                        ModelState.AddModelError("", taskUpdate.Errors.First().Description);
                    }

                    if (model.IsAdmin)
                    {
                        await _userManager.AddToRoleAsync(dbUser, AuthenticatorConstants.ADMIN_ROLE);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(dbUser, AuthenticatorConstants.ADMIN_ROLE);
                    }

                }
                if (ModelState.IsValid)
                {
                    TempData[TempDataConstants.TEMP_DATA_INFO_MESSAGE] = "Cập nhật thành công user: " + dbUser.UserName;
                    return RedirectToAction("Index");
                }
            }


            return View(model);
        }

        public IActionResult GetGgAuthenticator(string id)
        {
            LianUser dbUser = _userManager.Users.FirstOrDefault(item => item.Id == id);
            if (dbUser != null)
            {
                TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
                var setupInfo = twoFactor.GenerateSetupCode(
                    _configuration[Commons.Constants.GeneralConstants.APP_NAME_AUTHENTICATOR],
                    dbUser.Email,
                    Encoding.ASCII.GetBytes(dbUser.GoogleAuthenticatorSecretCode)
                );
                return Ok(setupInfo);
            }
            return null;
        }

    }
}

using LianAgentPortal.Commons.Constants;
using LianAgentPortal.Data;
using LianAgentPortal.Models.ViewModels.LianAgent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LianAgentPortal.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _db;
        public BaseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsCurrentUserHasRoleAdmin
        {
            get
            {
                return User.IsInRole(AuthenticatorConstants.ADMIN_ROLE);
            }
        }

        public LianAgentApiKey CurrentUserApiKey
        {
            get
            {
                // cant apply singletone
                // what if user make change to agent

                var user = _db.Users.Include(item => item.LianAgent).FirstOrDefault(item => item.UserName == User.Identity.Name);
                if (user != null && user.LianAgent != null)
                {
                    return new LianAgentApiKey()
                    {
                        AppId = user.LianAgent.AppId,
                        SecretKey = user.LianAgent.SecretKey,
                    };
                }
                return null;
            }

        }

    }
}

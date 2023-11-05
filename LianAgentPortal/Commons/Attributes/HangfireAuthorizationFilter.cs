using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml.Office;
using Hangfire.Dashboard;
using LianAgentPortal.Commons.Constants;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;

namespace LianAgentPortal.Commons.Attributes
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext currentContext)
        {
            try
            {
                var httpContext = ((AspNetCoreDashboardContext)currentContext).HttpContext;
                return httpContext.User.IsInRole(AuthenticatorConstants.ADMIN_ROLE);
            }
            catch
            {
                return false;
            }
        }
    }
}

using Showroom.Domain.Entitis.UserEntities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Showroom.Infrastructure.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            User user = (User)filterContext.HttpContext.Items["User"];

            if (user == null)
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }
    }
}

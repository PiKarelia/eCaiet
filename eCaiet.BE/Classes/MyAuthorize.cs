using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace eCaiet.BE.Classes
{
    public class MyAuthorize : AuthorizeAttribute
    {
        public MyAuthorize()
        {
            
        }

        /*protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");

            // Make sure the user is authenticated.
            if (httpContext.User.Identity.IsAuthenticated == false) return false;

            // Do you own custom stuff here
            bool allow = CheckIfAllowedToAccessStuff();

            return allow;
        }*/

        /*
                public override void OnAuthorization(AuthorizationContext filterContext)
                {
                    base.OnAuthorization(filterContext);
                    CheckIfUserIsAuthenticated(filterContext);
                }*/
    }
}

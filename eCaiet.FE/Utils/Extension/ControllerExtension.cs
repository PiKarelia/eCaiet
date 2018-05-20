using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Utils.Extension
{
    public static class ControllerExtension
    {
        public static AuthenticationHeaderValue GetUserAuthToken(this Controller controller)
        {
            return new AuthenticationHeaderValue("Bearer", controller.HttpContext.Request.Cookies["Authorization"]);
        }
    }
}

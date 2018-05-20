using System.Net;
using System.Net.Http.Headers;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Controllers
{
    public class ContentController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ContentController));

        public IActionResult ViewCourses()
        {
            return View();
        }
    }
}
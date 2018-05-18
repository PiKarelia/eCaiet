using System.Net;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Controllers
{
    public class ContentController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ContentController));

        //[Authorization()]
        public IActionResult ViewCourses()
        {
            return View();
        }
    }
}
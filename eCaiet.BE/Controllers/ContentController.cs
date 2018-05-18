using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.BE.Controllers
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
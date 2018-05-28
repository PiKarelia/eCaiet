using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using eCaiet.DAL.Models.DB;
using eCaiet.FE.Services.Interfaces;
using eCaiet.FE.Services.Managers.API;
using eCaiet.FE.Utils.Extension;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Controllers
{
    public class CourseController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CourseController));

        private readonly ApiContentController _contentControllerBE;

        public CourseController(ApiContentController contentControllerBE)
        {
            _contentControllerBE = contentControllerBE;
        }

        [HttpGet]
        public IActionResult ViewCourses()
        {
            var token = this.GetUserAuthToken();
            
            var data = _contentControllerBE.GetAllcourses(token);

            return View(data);
        }

        [HttpGet]
        public IActionResult CoursePage(Guid course)
        {
            var token = this.GetUserAuthToken();

            var files = _contentControllerBE.GetCourseWithFilesByGuid(token, course);
            return View(files);
        }

        [HttpPost]
        public JsonResult AddFile(File file)
        {
            var token = this.GetUserAuthToken();
            var res = _contentControllerBE.AddFile(token, file);
            return new JsonResult(res);
        }
    }
}
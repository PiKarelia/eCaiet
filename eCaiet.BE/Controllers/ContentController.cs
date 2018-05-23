using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.DAL.Repos.Interfaces;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.BE.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ContentController));

        private ICoursesRepo _courseRepo;

        public ContentController(ICoursesRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public IActionResult GetAllcourses(/*[FromHeader] */)
        {

            //_courseRepo.GetAllUserCourses();
            return Ok("courses");
        }
    }
}
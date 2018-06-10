using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.BE.Utils;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Repos.Interfaces;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult GetAllcourses()
        {
            var userGuid = HttpContext.GetUser().Guid;

            var res = _courseRepo.GetAllUserCourses(userGuid);
            
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetCourseWithFilesByGuid(Guid course)
        {
            var res = _courseRepo.GetCourseWithFilesByGuid(course);

            return Ok(JsonConvert.SerializeObject(res,Formatting.None,new JsonSerializerSettings(){ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
        }

        [HttpPost]
        public IActionResult AddFile([FromBody]File file)
        {
            var res = _courseRepo.AddFile(file);
            if (!res) return BadRequest();
            return Ok("yas");
        }

        [HttpPost]
        public IActionResult EditFile([FromBody] File file)
        {
            var res = _courseRepo.EditFile(file);
            if (!res) return BadRequest();
            return Ok("yas");
        }
    }
}
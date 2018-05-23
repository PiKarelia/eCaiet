using System;
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

        private readonly ApiAccountController _accountConstrollerBE;

        public CourseController(ApiAccountController accountConstrollerBE)
        {
            _accountConstrollerBE = accountConstrollerBE;
        }

        [HttpGet]
        public IActionResult ViewCourses()
        {
            var token = this.GetUserAuthToken();
            //var res = _accountConstrollerBE.Token();
            var data = new[]
            {
                new Course()
                {
                    UserGuid = Guid.NewGuid(),
                    Guid = Guid.NewGuid(),
                    User = null,
                    Name = "SDMP",
                    Description = "sami bag unbrela",
                    CreationDate = DateTime.Now.AddDays(131),
                    LastUpdateDate = DateTime.Now.AddDays(131),
                    Public = true
                },
                new Course()
                {
                    UserGuid = Guid.NewGuid(),
                    Guid = Guid.NewGuid(),
                    User = null,
                    Name = "PSI",
                    Description = "Proiectare huiare",
                    CreationDate = DateTime.Now.AddDays(31),
                    LastUpdateDate = DateTime.Now.AddDays(31),
                    Public = true
                },
                new Course()
                {
                    UserGuid = Guid.NewGuid(),
                    Guid = Guid.NewGuid(),
                    User = null,
                    Name = "Relete",
                    Description = "Relete intormaticeRelete intormaticeRelete intormaticeRelete intormatice",
                    CreationDate = DateTime.Now.AddMonths(31),
                    LastUpdateDate = DateTime.Now.AddMonths(31),
                    Public = true
                },
            };

            return View(data);
        }
    }
}
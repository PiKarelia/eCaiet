using System;
using eCaiet.DAL.Models.View;

using eCaiet.FE.Services.Managers.API;
using eCaiet.FE.Utils.Extension;
using log4net;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Controllers
{
    //[Route("")]
    public class AccountController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));

        private readonly ApiAccountController _client;

        public AccountController(ApiAccountController client)
        {
            _client = client;
        }
        
        public IActionResult Index()
        {
            string token;
            HttpContext.Request.Cookies.TryGetValue("Authorization",out token);
            if (string.IsNullOrEmpty(token)) RedirectToAction("Index", "Home");
            Log.Debug("Entering Index");
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Token([FromForm] LoginModel loginModel)
        {
            try
            {
                var token = _client.Token(loginModel);
                Response.Cookies.Append("Authorization", token);
                return RedirectToAction("ViewCourses", "Course");
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("Authorization");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Friends()
        {
            return View();
        }

    }
}
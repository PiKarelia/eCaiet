using System;
using eCaiet.DAL.Models.View;

using eCaiet.FE.Services.Managers.API;
using log4net;
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
                return RedirectToAction("ViewCourses", "Content");
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }
    }
}
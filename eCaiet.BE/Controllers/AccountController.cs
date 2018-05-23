using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.BE.Classes.InjectedInterfaces;
using eCaiet.BE.Classes.Utilities;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Models.View;
using eCaiet.DAL.Repos.Interfaces;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.BE.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));

        private readonly ITokenBuilder _tokenBuilder;

        private IUsersRepo _userRepo;

        public AccountController(ITokenBuilder tokenBuilder, IUsersRepo userRepo)
        {
            _tokenBuilder = tokenBuilder;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            Log.Debug("Entering Index");
            return Ok(); 
        }

        [HttpPost]
        public IActionResult Token([FromBody]LoginModel loginModel)
        {
            Log.Debug("in authenticate: login="+ loginModel.Login);

            if (string.IsNullOrEmpty(loginModel.Password) || string.IsNullOrEmpty(loginModel.Login))
                return BadRequest();

            loginModel.Password = MD5GEnerator.GetMD5(loginModel.Password);

            var user = _userRepo.Authorize(loginModel);

            if (user == null)
                return BadRequest();
            
            var token = _tokenBuilder.Generate(user);
            Log.Debug(token);

            return Ok(token);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.BE.Classes.InjectedInterfaces;
using eCaiet.BE.Classes.Utilities;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Models.View;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.BE.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));

        private readonly ITokenBuilder _tokenBuilder;

        private readonly DAL.DAL _dal;


        public AccountController(ITokenBuilder tokenBuilder/*,UsersTable userTable*/, DAL.DAL dal)
        {
            _tokenBuilder = tokenBuilder;
            _dal = dal;
        }

        public IActionResult Index()

        {
            Log.Debug("Entering Index");
            return Ok(); //View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Authenticate(LoginModel loginModel)
        {
            Log.Debug("in authenticate: login="+ loginModel.Login);

            //TODO trie to pass just user repo insead of
            var user = _dal.Users.Authorize(loginModel);

            loginModel.Password = MD5GEnerator.GetMD5(loginModel.Password);
            /*var user = new User()
            {
                Email = "ana.grigorcea@yopmail.com",
                FirstName = "Ana",
                LastName = "Grigorcea",
                Guid = new Guid("e3968e57-3fd8-4be1-98aa-75c69cb150c9"),
                Login = "anag",
                Password = "7C8B7AFAAC654C4DD276BF94CF996A43"
            };*/

            //var user = UserTable.Auth
            
            var token = _tokenBuilder.Generate(user);
            Log.Debug(token);
            //INSERT TO CACHE __ NOTE HERE
            //return (IActionResult)Ok(token);

            return Ok(token); //return RedirectToAction("Index", "Home");
        }
    }
}
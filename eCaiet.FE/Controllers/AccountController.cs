using Microsoft.AspNetCore.Mvc;

namespace eCaiet.FE.Controllers
{
    public class AccountController : Controller
    {
        /*private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));

        private readonly ITokenBuilder _tokenBuilder;


        public AccountController(ITokenBuilder tokenBuilder/*,UsersTable userTable#1#)
        {
            _tokenBuilder = tokenBuilder;
        }

        public IActionResult Index()

        {
            Log.Debug("Entering Index");
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Authenticate(LoginModel loginModel)
        {
            Log.Debug("in authenticate: login="+ loginModel.Login);
            loginModel.Password = MD5GEnerator.GetMD5(loginModel.Password);
            var user = new User()
            {
                Email = "ana.grigorcea@yopmail.com",
                FirstName = "Ana",
                LastName = "Grigorcea",
                Guid = new Guid("e3968e57-3fd8-4be1-98aa-75c69cb150c9"),
                Login = "anag",
                Password = "7C8B7AFAAC654C4DD276BF94CF996A43"
            };


            //var user = UserTable.Auth
            
            var token = _tokenBuilder.Generate(user);
            Log.Debug(token);
            //INSERT TO CACHE 
            //return (IActionResult)Ok(token);

            return RedirectToAction("Index", "Home");
        }*/
    }
}
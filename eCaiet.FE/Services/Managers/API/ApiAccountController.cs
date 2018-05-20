using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.DAL.Models.View;
using eCaiet.FE.Services.Interfaces;

namespace eCaiet.FE.Services.Managers.API
{
    public class ApiAccountController
    {
        private readonly IApiConnector _connector;

        private static string GetPath(string method) => $"Account/{method}";

        public ApiAccountController(IApiConnector connector)
        {
            _connector = connector;
        }

        public string Token(LoginModel loginModel)
        {
            var method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var task = _connector.PostAsync<string, LoginModel>(GetPath(method), loginModel);
            task.Wait();
            return task.Result;
        }
    }
}

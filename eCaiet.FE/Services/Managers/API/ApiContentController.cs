using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.FE.Services.Interfaces;

namespace eCaiet.FE.Services.Managers.API
{
    public class ApiContentController
    {
        private readonly IApiConnector _connector;

        private static string GetPath(string method) => $"Content/{method}";

        public ApiContentController(IApiConnector connector)
        {
            _connector = connector;
        }

        //public 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eCaiet.DAL.Models.DB;
using eCaiet.FE.Services.Interfaces;
using Newtonsoft.Json;

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

        public IEnumerable<Course> GetAllcourses(AuthenticationHeaderValue token)
        {
            var method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var task = _connector.GetAsync<IEnumerable<Course>>(GetPath(method),token);
            task.Wait();
            return task.Result;
        }

        public Course GetCourseWithFilesByGuid(AuthenticationHeaderValue token, Guid courseGuid)
        {
            var method = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var task = _connector.GetAsync<string>(GetPath(method)+"?course="+courseGuid, token);
            task.Wait();
            return JsonConvert.DeserializeObject<Course>(task.Result);
        }

        public bool AddFile(AuthenticationHeaderValue token, File file)
        {
            //TODO handle errors as needed
            try
            {
                var method = System.Reflection.MethodBase.GetCurrentMethod().Name;
                var task = _connector.PostAsync<File>(GetPath(method), file, token);
                task.Wait();
                return true;
            }
            catch 
            {
                //todo logging
                return false;
            }
        }
    }
}

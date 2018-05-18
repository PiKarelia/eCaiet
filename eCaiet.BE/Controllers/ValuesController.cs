using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace eCaiet.BE.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ValuesController));

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Log.Debug("entering Get");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

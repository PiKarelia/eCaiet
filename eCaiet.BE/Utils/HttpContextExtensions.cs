using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCaiet.DAL.Models.DB;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace eCaiet.BE.Utils
{
    internal static class HttpContextExtensions
    {
        public static User GetUser(this HttpContext context)
        {
            foreach (var claim in context.User.Claims)
            {
                try
                {
                    return JsonConvert.DeserializeObject<User>(claim.Value);
                }
                catch
                {
                }
            }

            return null;
        }
    }
}

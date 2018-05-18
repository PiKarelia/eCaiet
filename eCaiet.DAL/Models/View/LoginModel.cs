using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.View
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Models.View;

namespace eCaiet.DAL.Repos.Interfaces
{
    public interface IUsersRepo
    {
        User Authorize(LoginModel l);
    }
}

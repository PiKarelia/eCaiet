using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCaiet.DAL.Entity;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Models.View;
using eCaiet.DAL.Repos.Interfaces;

namespace eCaiet.DAL.Repos
{
    class UsersRepo :IUsersRepo
    {
        private readonly EDbContext _db;

        public UsersRepo(EDbContext db)
        {
            _db = db;
        }

        public User Authorize(LoginModel l)
        {
            return _db.Users.FirstOrDefault(u => u.Login.Equals(l.Login) && u.Password.Equals(l.Password));
        }
    }
}

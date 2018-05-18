using System;
using eCaiet.DAL.Entity;
using eCaiet.DAL.Repos;
using eCaiet.DAL.Repos.Interfaces;

namespace eCaiet.DAL
{
    public class DAL
    {

        public DAL(EDbContext db)
        {
            Users = new UsersRepo(db);
        }

        public IUsersRepo Users { get; set; }

    }
}

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
            Courses = new CoursesRepo(db);
        }

        public IUsersRepo Users { get; set; }

        public ICoursesRepo Courses { get; set; }
    }
}

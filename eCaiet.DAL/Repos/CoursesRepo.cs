using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCaiet.DAL.Entity;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Repos.Interfaces;

namespace eCaiet.DAL.Repos
{
    class CoursesRepo :ICoursesRepo
    {
        private readonly EDbContext _db;

        public CoursesRepo(EDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Course> GetAllUserCourses(Guid user)
        {
            return _db.Courses.Where(u => u.UserGuid == user);
        }
    }
}

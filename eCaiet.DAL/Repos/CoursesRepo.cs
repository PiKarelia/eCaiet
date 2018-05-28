using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCaiet.DAL.Entity;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _db.Courses.Where(u => u.UserGuid == user).OrderByDescending(x => x.LastUpdateDate);
        }

        public Course GetCourseWithFilesByGuid(Guid course)
        {
            return _db.Courses.Include(x => x.Files).FirstOrDefault(x => x.Guid == course);

        }

        public bool AddFile(File file)
        {
            //TODO implement proxy pattern for validation

            //TODO update last modified date of course
            if (_db.Courses.Any(x => x.Guid == file.CourseGuid) && !string.IsNullOrEmpty(file.Name))
                _db.Files.Add(file);
            else
            {
                return false;
            }
            var nr = _db.SaveChanges();
            return nr > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;

namespace eCaiet.DAL.Repos.Interfaces
{
    public interface ICoursesRepo
    {
        IEnumerable<Course> GetAllUserCourses(Guid user);
        Course GetCourseWithFilesByGuid(Guid course);
        bool AddFile(File file);
        bool EditFile(File file);
    }
}

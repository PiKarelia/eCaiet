using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;

namespace eCaiet.DAL.Repos.Interfaces
{
    public interface ICoursesRepo
    {
        IEnumerable<Course> GetAllUserCourses(Guid user);
    }
}

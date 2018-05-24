using System;
using System.Collections.Generic;
using System.Text;
using eCaiet.DAL.Models.DB;

namespace eCaiet.DAL.Repos.Interfaces
{
    public interface IFilesRepo
    {
        IEnumerable<File> GetAllCourseFiles(Guid course);
        File GetUserAvatar(Guid user);
    }
}

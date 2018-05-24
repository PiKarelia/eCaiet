using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCaiet.DAL.Entity;
using eCaiet.DAL.Models.DB;
using eCaiet.DAL.Repos.Interfaces;

namespace eCaiet.DAL.Repos
{
    class FilesRepo : IFilesRepo
    {
        private readonly EDbContext _db;

        public FilesRepo(EDbContext db)
        {
            _db = db;
        }

        public IEnumerable<File> GetAllCourseFiles(Guid course)
        {
            return _db.Files.Where(x => x.CourseGuid == course);
        }

        public File GetUserAvatar(Guid user)
        {
            return _db.Files.FirstOrDefault(x => x.Guid == user);
        }
    }
}

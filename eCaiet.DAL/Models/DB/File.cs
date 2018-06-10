using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.DB
{
    public class File
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid? OwnerGuid { get; set; }
        public User Owner { get; set; }
        public Guid? CourseGuid { get; set; }
        public Course Course { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.DB
{
    public class Course
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool Public { get; set; }
        public Guid UserGuid { get; set; }
        public User User { get; set; }
    }
}

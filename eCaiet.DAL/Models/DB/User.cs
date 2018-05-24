using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.DB
{
    public class User
    {
        public Guid Guid { get; set; } 
        public string Login { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 

        public File Avartar{ get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}

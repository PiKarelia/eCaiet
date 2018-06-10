using System;
using System.Collections.Generic;
using System.Text;

namespace eCaiet.DAL.Models.DB
{
    public class Friend
    {
        public Guid Friend1Guid { get; set; }
        public Guid Friend2Guid { get; set; }

        public User Friend1 { get; set; }
        public User Friend2 { get; set; }
    }
}

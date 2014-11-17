using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Models
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int Creater { get; set; }

        public string Remarks { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }
    }
}
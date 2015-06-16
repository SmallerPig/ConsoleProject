using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Models
{
    public class LoginLog:ModelBase
    {
        public string UserName { get; set; }

        public string IpAddress { get; set; }
    }
}
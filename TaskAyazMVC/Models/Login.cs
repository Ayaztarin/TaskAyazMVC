using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAyazMVC.Models
{
    public class Login
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; internal set; }
    }
}
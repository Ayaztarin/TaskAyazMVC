using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskAyazMVC.Models
{
    public class EmpModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Book_Name { get; set; }
        public string Publication { get; set; }
        public string Author { get; set; }
    }
}
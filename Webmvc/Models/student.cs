using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmvc.Models
{
    public class student
    {

        public int StudentId { get; set; }
        public int Age  { get; set; }
        public string StudentName { get; set; }
        public string MobileNo { get; set; }
        public List<student> usersinfo { get; set; }


    }
}
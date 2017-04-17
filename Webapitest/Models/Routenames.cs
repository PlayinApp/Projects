using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class Routenames
    {
        public int routeid { get; set; }
        public string routeName { get; set; }
        public int empId { get; set; }
        public int shift { get; set; }
       
        public bool status { get; set; }


    }
}
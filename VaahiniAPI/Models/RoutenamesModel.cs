using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class RouteAssighnmentModel
    {

        public int routeid { get; set; }
        public string routeName { get; set; }
        public int empid { get; set; }
        public int shiftid { get; set; }
        public int driverid { get; set; }
        public int result { get; set; }
        public string actionstatus { get; set; }

        public bool status { get; set; }
    }
}
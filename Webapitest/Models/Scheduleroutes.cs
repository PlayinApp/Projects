using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class Scheduleroutes
    {
        public int scheduleId { get; set; }
        public int routeid { get; set; }
        public int driverid { get; set; }
        public int vehicleId { get; set; }
        public int triptype { get; set; }
        public int empId { get; set; }
       

        public bool status { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class EmployeeModel
    {
        public int empId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string presentAddress { get; set; }
        public string landmark { get; set; }
        public string gender { get; set; }
        public string companybranch { get; set; }
        public string pickuplocation { get; set; }
        public double pickupLatitude { get; set; }
        public double pickupLongitude { get; set; }
        public string profilePic { get; set; }
        public string inspectedBy { get; set; }
        public int deviceId { get; set; }
        public int locationId { get; set; }
        public int Age { get; set; }
        public int shift { get; set; }

        public bool status { get; set; }



    }
}
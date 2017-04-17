using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class EmployeeModel
    {

       public int workstatusId { get; set; }
        public int empId { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }

        public string pin { get; set; }

        public string token { get; set; }
       
        public object userId { get; set; }
        public object useridfk { get; set; }
        public string usertype { get; set; }
        public string authKey { get; set; }
        public string presentAddress { get; set; }
        public double presentLatitude { get; set; }
        public double presentLongitude { get; set; }


        public string landmark { get; set; }
        public string gender { get; set; }
        public string companybranch { get; set; }

        public string pickuplocation { get; set; }
        public double pickupLatitude { get; set; }
        public double pickupLongitude { get; set; }
        public string profilePic { get; set; }

        public string base64image { get; set; }
        public string emergencycontact { get; set; }
       

        public int deviceId { get; set; }
        public int locationId { get; set; }
        public int Age { get; set; }
        public int shift { get; set; }

        public bool status { get; set; }


    }
}
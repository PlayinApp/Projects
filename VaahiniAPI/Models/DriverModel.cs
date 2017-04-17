using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class DriverModel
    {
        public string token { get; set; }
        public string mobile { get; set; }
        public string pin { get; set; }
       
        public string  userId { get; set; }
        public int userid { get; set; }
        public int routeid { get; set; }
        public string usertype { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int driverid { get; set; }
        public string emergencyContact { get; set; }
        public string panno { get; set; }
        public  double presentLatitude { get; set; }
        public double presentLongitude { get; set; }
        public string presentAddress { get; set; }
        public float experience { get; set; }
        public string currentAddr { get; set; }
        public string permanentAaddr { get; set; }
        public string licenceno { get; set; }
        public string fromdateTodate { get; set; }
        public string transportCompany { get; set; }
        public string vehicleno { get; set; }

        public string aadharNo { get; set; }
        public string profilePic { get; set; }
        public string base64image { get; set; }
        public string bloodGroup { get; set; }
        public int eyeSight { get; set; }
        public string breathTest { get; set; }
        public bool lifeInsurance { get; set; }
        public bool isComsumeAlcohal { get; set; }
        public bool isSmoke { get; set; }
        public string physicalInjuries { get; set; }
        public string otherhealthIssues { get; set; }
        public int deviceId { get; set; }

        public bool status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class DriverModel
    {

        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string emergencyContact { get; set; }
        public string panno { get; set; }

        public  float experience { get; set; }
        public string currentAddr { get; set; }
        public string permanentAaddr { get; set; }
        public string licenceno { get; set; }
        public string fromdateTodate { get; set; }
        public string transportCompany { get; set; }
        public string vehicleno { get; set; }
       
        public string aadharNo { get; set; }
        public string profilePic { get; set; }
      
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
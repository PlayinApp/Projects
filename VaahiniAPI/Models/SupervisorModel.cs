using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class SupervisorModel
    {

        public int superVisorId { get; set; }
        public string name { get; set; }
        public string userid { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string company { get; set; }
        public string orgEmpId { get; set; }
        public string perAddress { get; set; }
        public string emergencyContact { get; set; }
        public string aadharNo { get; set; }
        public string base64image { get; set; }
        public string profilePic { get; set; }
        public bool status { get; set; }
    }
}
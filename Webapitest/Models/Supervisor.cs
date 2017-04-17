using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class Supervisor
    {

        public int superVisorId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string company{ get; set; }
        public string orgEmpId { get; set; }
        public string perAddress { get; set; }
        public string emergencyContact { get; set; }
        public string aadharNo { get; set; }
        public string profilePic { get; set; }
        public bool status { get; set; }

    }
}
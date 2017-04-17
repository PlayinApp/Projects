using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string mobile { get; set; }

        public string pin { get; set; }

        public string newPin { get; set; }

        public int  driverId { get; set; }

        public int empId  { get; set; }
        public string token { get; set; }

        public string userId { get; set; }
        public int useridFK { get; set; }
        public string devicekey { get; set; }

        public string deviceOs { get; set; }

        public string deviceOsVersion { get; set; }
        public string deviceModel { get; set; }
        public string userType { get; set; }



        public int OTP { get; set; }








    }
}
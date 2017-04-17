using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class SosAlertsModel
    {
        public int sosid { get; set; }
        public int userIdfk { get; set; }
        public string userId { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string address { get; set; }

        public bool status { get; set; }


    }
}
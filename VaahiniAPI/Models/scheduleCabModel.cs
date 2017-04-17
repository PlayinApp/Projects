using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class scheduleCabModel
    {
        public int schedulecabid { get; set; }
        public int empid { get; set; }
        public DateTime requestdate { get; set; }
        public string requesttime { get; set; }
        public int ridestatus { get; set; }
        public int responseid  { get; set; }
        public int locationid { get; set; }
        public string userid { get; set; }
        public int requestid { get; set; }
        public int vehicleid { get; set; }
        public int driverid { get; set; }

        public DateTime availabledate { get; set; }
        public TimeSpan availabletime { get; set; }
        public string message { get; set; }

        public DateTime responsetimebysp { get; set; }
        public DateTime accepttimebysp { get; set; }
        public DateTime rejecttimesp { get; set; }

        public DateTime canceltimebyemp { get; set; }
       
        public Boolean status { get; set; }



    }
}
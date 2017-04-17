using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class DriverTripsModel
    {
        public string token { get; set; }
        public int drivertripid { get; set; }
        public int driverid { get; set; }
        public int vehicleid { get; set; }
        public string triptype { get; set; }
        public DateTime startdatetime { get; set; }

       

        public DateTime enddatetime { get; set; }

        public double startlatitude { get; set; }
        public double startlongititude { get; set; }
        public double endlatitude { get; set; }
        public double endlongititude { get; set; }
        public int tripstatus { get; set; }

        public int routeid { get; set; }


        public bool status { get; set; }
    }
}
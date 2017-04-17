using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class EmptripsModel
    {
        public string token { get; set; }
        public int emptripId { get; set; }
        public int empid { get; set; }
        

        public string startLatitude { get; set; }
        public string startLongititude { get; set; }
        public string startAddress { get; set; }
        public string endLatitude { get; set; }
        public string endLongitude { get; set; }
        public string endAddress { get; set; }
        public string triptype { get; set; }
        public int routeId { get; set; }
        public int tripstatus { get; set; }
        public int userIdfk { get; set; }
        public string userId { get; set; }
        public string userType { get; set; }
        public bool status { get; set; }
        public bool isemergencystop { get; set; }


    }
}
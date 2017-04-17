using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class DriverTrips
    {

        public int driverTripId { get; set; }
        public int driverId { get; set; }
        public int vehicleId { get; set; }
        public int triptype { get; set; }
        public DateTime empidstartdatetime { get; set; }


        public DateTime enddatetime { get; set; }

        public double startLatitude { get; set; }
        public double startLongititude { get; set; }
        public double endLatitude { get; set; }
        public double endLongititude { get; set; }

        
        public int routeId { get; set; }


        public bool status { get; set; }
    }
}
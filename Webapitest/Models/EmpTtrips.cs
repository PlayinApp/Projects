using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class EmpTtrips
    {

        public int emptripid { get; set; }
        public int empid { get; set; }
        public DateTime empidstartdatetime { get; set; }
        

        public DateTime enddatetime { get; set; }

        public double startLatitude { get; set; }
        public double startLongititude { get; set; }
        public double endLatitude { get; set; }
        public double endLongititude { get; set; }

        public int triptype { get; set; }
         public int routeId { get; set; }

       
        public bool status { get; set; }
    }
}
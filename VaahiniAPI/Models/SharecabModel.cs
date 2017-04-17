using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class ShareCabModel
    {
        public int sharecabid { get; set; }
        public int empid { get; set; }
        public double presentlatitude { get; set; }
        public double presentlongitude  { get; set; }
        public int driverid { get; set; }
        public Boolean  status { get; set; }


    }
}
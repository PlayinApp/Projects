using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class PickuplocModel
    {

        public int locationid { get; set; }

        public string name { get; set; }
        public string pickuplat { get; set; }
        public string pickuplong { get; set; }

        public string pickupaddress { get; set; }

        public string placename { get; set; }
        public int userid { get; set; }
        public string userId { get; set; }
        public int idindex { get; set; }
        public bool status { get; set; }

    }
}
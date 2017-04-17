using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class VehicleModel
    {
        public int vehicleId { get; set; }
        public string vehNameModel { get; set; }
        public string vehicleRegNo { get; set; }
       
        public string vehicleCondition { get; set; }
        public bool isContainFirstAID { get; set; }
        public bool isContainAirbags { get; set; }
        public bool isContainsFireControll { get; set; }
        public bool isVehicleowned { get; set; }
        public string ownername { get; set; }
        public string ownerNumder { get; set; }
        public string ownerAddress { get; set; }
        public string inspectedBy { get; set; }

        public string vehicletype { get; set; }
        
        public bool status { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class DevicesModel
    {
        public int DeviceId { get; set; }
        public int empId { get; set; }
        public int supervisorId { get; set; }
        public int driverId { get; set; }
        public string fcmDeviceId { get; set; }
        public string deviceModel { get; set; }

        public int deviceOs { get; set; }
        public string deviceOsVersion { get; set; }
        public string devicekey { get; set; }

        public bool status { get; set; }



    }
}
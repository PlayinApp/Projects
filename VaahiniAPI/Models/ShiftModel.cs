using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class ShiftModel
    {

        public string token { get; set; }

        public int shiftId { get; set; }

        public string shiftName { get; set; }

        public TimeSpan starttime { get; set; }

        public TimeSpan endtime { get; set; }

        public bool status { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webmvc.Models
{
    public class Shift
    {
        public int shiftid { get; set; }
        public String shiftname { get; set; }
        public String starttime { get; set; }
        public string endtime { get; set; }
        //   public String Command { get; set; }

    }
}
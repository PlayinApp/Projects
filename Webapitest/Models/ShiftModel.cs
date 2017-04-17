using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapitest.Models
{
    public class ShiftModel
    {
        public int shiftId { get; set; }
        public string shiftName { get; set; }
        public bool status { get; set; }
    }
}
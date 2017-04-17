using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;

namespace VaahiniAPI.Models
{
    public class ComplaintsModel
    {
        public int complaintid { get; set; }

      
        public int empid { get; set; }
        public int driverid { get; set; }
        public int vehicleid { get; set; }
        public string complaintContent { get; set; }
        public string others { get; set; }
        public string userid { get; set; }
        public string complainttype { get; set; }



    }
}
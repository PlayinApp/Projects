using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace VaahiniAPI.Models
{
    public class ResponseModel
    {
        public String message { get; set; }
        public  bool error { get; set; }
       
        public object output { get; set; }
        public int statuscode { get; set; }

        public ResponseModel()
        {
        }


    }
}
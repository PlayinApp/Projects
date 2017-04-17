using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Webapitest.Models
{
    public class LoginResponseModel
    {


        public String message { get; set; }
        public string token { get; set; }
        public IEnumerable<Tbl_Driver> output { get; set; }
        public DataTable output1 { get; set; }
       public int statuscode { get; set; }
        
        public LoginResponseModel()
        {
        }
    }
}
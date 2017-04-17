using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class LoginResponseModel
    {
        public String Message { get; set; }
        public IEnumerable<Tbl_Driver> Output { get; set; }
        public LoginResponseModel()
        {
        }


    }
}
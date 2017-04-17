using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDATA.Models;

namespace WebAPIDATA.Controllers
{
    public class emplyeeController : ApiController
    {
        SampleEntities db = new SampleEntities();

        [HttpGet]
        public IEnumerable<Sp_Emplyee_Result> Getdata()

        {



            return db.Sp_Emplyee(null, "SELECT").AsEnumerable();

        }
    }
}

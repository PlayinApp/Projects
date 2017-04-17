using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        SampleEntities5 db = new SampleEntities5();

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post()
        {
            var msf = db.Tbl_Driver1.AsEnumerable();

    var resp = Request.CreateResponse<LoginResponseModel>(
        HttpStatusCode.OK,
        new LoginResponseModel() { Message ="success", Output =msf }
    );
            return resp;
        }
    }
}

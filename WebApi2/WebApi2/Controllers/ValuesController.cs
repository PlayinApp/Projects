using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.Models;

namespace WebApi2.Controllers
{
   // [Authorize]
    public class ValuesController : ApiController
    {


        // GET api/values
        //public ManageInfoViewModel Get()
        //{
        //    return ;
        //}

        public HttpResponseMessage Get()

        {
            string userid = UrlUtil.getParam(this, "userid", "");
            string pwd = UrlUtil.getParam(this, "pwd", "");
            string resp = DynAggrClientAPI.openSession(userid, pwd);

            resp = "{\"status\":\"SUCCESS\",\"data\":}";
                
                  // TEST !!!!!           

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(resp, System.Text.Encoding.UTF8, "application/json");
            return response;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

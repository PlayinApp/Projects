using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.Models;
using VaahiniAPI.DAL;
using System.Data;
using System.Data.SqlClient;


namespace VaahiniAPI.Controllers
{
    public class ScheduleroutesController : ApiController
    {

        DataTable dt = new DataTable();
        ScheduleroutesModel objScheduleroutesModel = new ScheduleroutesModel();
        ScheduleroutesDL objScheduleroutesDL = new ScheduleroutesDL();
        [HttpPost]
        [Route("supervisor/scheduleroutes")]
        public HttpResponseMessage scheduleroutes([FromBody] ScheduleroutesModel objScheduleroutesModel)
        {

             objScheduleroutesDL.insert_scheduleroutes(objScheduleroutesModel);

             var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
             new ResponseModel() { message = "scheduledroutes successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
             return resp;
        }

        [HttpPost]
        [Route("supervisor/Getscheduleroutes")]
        public HttpResponseMessage Getscheduleroutes()
        {

           dt= objScheduleroutesDL.getscheduleroutes();
            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
           new ResponseModel() { message = "ok successfull",output=dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

    }
}

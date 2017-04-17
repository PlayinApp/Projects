using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;

namespace VaahiniAPI.Controllers
{
    public class ComplaintsController : ApiController
    {
        string token;
        AuthorizationToken Authtoken = new AuthorizationToken();
        DataTable dt = new DataTable();
        ComplaintsDL objComplaintsDL = new ComplaintsDL();
        ComplaintsModel objComplaintsModel = new ComplaintsModel();
        [HttpPost]
        [Route("employee/complaint_List")]
        public HttpResponseMessage employeeList([FromBody] ComplaintsModel objComplaintsModel)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            var result = Authtoken.checkToken(token);
            if (result == true)
            {

                dt = objComplaintsDL.getdrivercomplaintlist(objComplaintsModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "complaint added successfully", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }

        [HttpPost]
        [Route("employee/drivercomplaint")]
        public HttpResponseMessage drivercomplaint([FromBody] ComplaintsModel objComplaintsModel)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            var result = Authtoken.checkToken(token);
            if (result == true)
            {

                objComplaintsDL.insert_driverComplaints(objComplaintsModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "complaint added successfully",  statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }
        [HttpPost]
        [Route("employee/vehiclecomplaint")]
        public HttpResponseMessage vehiclecomplaint([FromBody] ComplaintsModel objComplaintsModel)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            var result = Authtoken.checkToken(token);
            if (result == true)
            {

                 objComplaintsDL.insert_vehicleComplaints(objComplaintsModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "complaint added successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }
        [HttpPost]
        [Route("employee/supervisorcomplaint")]
        public HttpResponseMessage supervisorcomplaint([FromBody] ComplaintsModel objComplaintsModel)
        {
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            var result = Authtoken.checkToken(token);
            if (result == true)
            {

                 objComplaintsDL.insert_supervisorComplaints(objComplaintsModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "ok successful",  statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.Models;
using VaahiniAPI.DAL;
using System.Data;

namespace VaahiniAPI.Controllers
{
    public class ShiftController : ApiController
    {

        shiftDL objshiftDL = new shiftDL();
        AuthorizationToken Authtoken = new AuthorizationToken();
        DataTable dt = new DataTable();
        [HttpPost]
        [Route("supervisor/create_shift")]
        public HttpResponseMessage createEmployee([FromBody] ShiftModel objShiftModel)
        {

            if (objShiftModel.token == null)
            {
                //token from user
                var token = objShiftModel.token;
                //checking Token
                var result = Authtoken.checkToken(token);
                if (result == true)
                {
                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                       new ResponseModel() { message = "no token", statuscode = Convert.ToInt16(HttpStatusCode.NoContent) });
                    return resp;
                }

                else
                {

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.NoContent) });
                    return resp;


                }

            }
            else
            {
                objshiftDL.insert_ShiftDetails(objShiftModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "Shift created sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;


            }
        }


        [HttpPost]
        [Route("supervisor/shift_List")]
        public HttpResponseMessage employeeList()
        {


            dt = objshiftDL.getshifts();

            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
 new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }



    }
}

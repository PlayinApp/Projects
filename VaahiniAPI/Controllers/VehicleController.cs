using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;
using System.Data;

namespace VaahiniAPI.Controllers
{
    public class VehicleController : ApiController
    {
        /// <summary>
        /// object creation
        /// </summary>
        VehicleDL objVehicleDL = new VehicleDL();
        DataTable dt = new DataTable();
        AuthorizationToken Authtoken = new AuthorizationToken();
        /// <summary>
        /// Registering vehicle
        /// </summary>
        /// <param name="objvehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("supervisor/RegisterVehicle")]
        public HttpResponseMessage Registervehicle([FromBody] VehicleModel objvehicleModel)
        {
            if (objvehicleModel.token == null)
            {

                //token from user
                var token = objvehicleModel.token;
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

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.NoContent) });
                    return resp;


                }

            }

            else
            {

                objVehicleDL.insert_vehicleDetails(objvehicleModel);


                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                new ResponseModel() { message = "Vehicle Register sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }


        }


        /// <summary>
        /// Getting Vehicle List
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("supervisor/Vehicle_List")]
        public HttpResponseMessage vehicleList()
        {



            dt = objVehicleDL.getVehicles();


            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
            new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;

        }


    }
}

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
    public class RouteallocationController : ApiController
    {
        DataTable dt = new DataTable();
        RouteAssignmentDL objRouteDL = new RouteAssignmentDL();
        AuthorizationToken Authtoken = new AuthorizationToken();
        DataTable dt1 = new DataTable();
        string token;


        [HttpPost]
        [Route("supervisor/create_routes")]
        public HttpResponseMessage createRoutes([FromBody]RouteAssighnmentModel[] objRouteAssighnmentModel)
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

                dt = objRouteDL.getroutes(objRouteAssighnmentModel[0].routeName);

                if (dt.Rows.Count > 0)
                {


                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                    new ResponseModel() { message = "already created this route", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;
                }
                else
                {
                    int routeid = objRouteDL.insert_Routenames(objRouteAssighnmentModel[0]);
                    for (int i = 0; i < objRouteAssighnmentModel.Length; i++)
                    {

                        objRouteAssighnmentModel[i].routeid = routeid;
                        objRouteDL.insert_Assighnment(objRouteAssighnmentModel[i]);

                    }
                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
         new ResponseModel() { message = "route Created sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;
                }
            }


            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }
        }


        [HttpPost]
        [Route("supervisor/routes_list")]
        public HttpResponseMessage routesList()
        {

            dt = objRouteDL.getrouteslist();

            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
 new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }



    }
}

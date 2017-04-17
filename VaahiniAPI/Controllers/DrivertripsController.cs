using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;

namespace VaahiniAPI.Controllers
{
    public class DrivertripsController : ApiController
    {
        DrivertripsDL objDrivertripsDL = new DrivertripsDL();

        AuthorizationToken Authtoken = new AuthorizationToken();
        DataTable dt = new DataTable();
        string token;
        [Route("driver/start_trip")]
        public HttpResponseMessage createDrivertrip([FromBody] DriverTripsModel objDrivertripsModel)
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
                dt.Columns.AddRange(new DataColumn[1] { new DataColumn("drivertripid", typeof(int))

                            });


                int drivertripid = objDrivertripsDL.insert_starttrip(objDrivertripsModel);
                // dt.Columns.Add("drivertripid", typeof(System.Int16));

                DataRow dr = dt.NewRow();
                dr["drivertripid"] = drivertripid; // or dr[0]="Mohammad";
                                                   // or dr[1]=24;
                dt.Rows.Add(dr);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "your trip started successfully", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK), error = false });
                return resp;
            }

            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }
        }

        [Route("driver/end_trip")]
        public HttpResponseMessage endDrivertrip([FromBody] DriverTripsModel objDrivertripsModel)
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


                objDrivertripsDL.insert_endttrip(objDrivertripsModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "your trip ended successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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

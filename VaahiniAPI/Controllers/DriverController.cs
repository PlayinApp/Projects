using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using VaahiniAPI.Models;
using VaahiniAPI.DAL;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace VaahiniAPI.Controllers
{
    public class DriverController : ApiController
    {
        DataTable dt = new DataTable();
        AuthorizationToken Authtoken = new AuthorizationToken();
        LoginModel objloginModel = new LoginModel();
        DriverDL objDriverDl = new DriverDL();
        RouteAssignmentDL objRouteAssignmentDL = new RouteAssignmentDL();
        string IP, token;
        /*---------------------------------------------------------------
        *                Register Driver Details
        *---------------------------------------------------------------
        */
        [HttpPost]
        [Route("supervisor/register_Driver")]
        public HttpResponseMessage registerDriver([FromBody]  DriverModel driverm)
        {

            // token from user
            var token = driverm.token;
            //checking Token
            var result = Authtoken.checkToken(token);
            if (result == true)

            {


                var Mobileexist = Authtoken.checkmobile(driverm.mobile);
                if (Mobileexist == false)
                {
                    /*---------------------------------------------------------------------------
                     *                           Inserting Login Details
                     * --------------------------------------------------------------------------
                     */

                    dt = objDriverDl.getDriverscount();
                    objloginModel.mobile = driverm.mobile;
                    objloginModel.pin = driverm.pin;
                    objloginModel.token = Authtoken.genarateToken();
                    objloginModel.userId = Authtoken.genarateUserId();
                    objloginModel.driverId = Convert.ToInt16(dt.Rows[0]["drivercount"].ToString()) + 1; ;
                    objloginModel.userType = "driver";
                    objDriverDl.insert_loginDetails(objloginModel);
                    /*---------------------------------------------------------------
                     *                        Insert Drivers Details
                     *---------------------------------------------------------------
                     */
                    driverm.userid = Authtoken.usercount() + 1;
                    objDriverDl.insert_DriverDetails(driverm);
                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                      new ResponseModel() { message = "Driver Register Succesfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                                      );
                    return resp;
                }



                else
                {

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                      new ResponseModel() { message = "Already This Mobileno Registered", statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                                      );
                    return resp;



                }
            }

            else
            {
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
          new ResponseModel() { message = "no token", statuscode = Convert.ToInt16(HttpStatusCode.NoContent) });
                return resp;
            }

        }
        /*---------------------------------------------------------------
         *                       Drivers List
         *---------------------------------------------------------------
         */


        [HttpPost]
        [Route("supervisor/Driver_List")]
        public HttpResponseMessage driverList()
        {


            dt = objDriverDl.getDrivers();

            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
            new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }
        /*--------------------------------------------------------------
        *                       Driver Profile Updation
        *---------------------------------------------------------------
        */
        [HttpPost]
        [Route("driver/updateProfile")]
        public HttpResponseMessage updateProfile([FromBody] DriverModel driverm)
        {
            IP = System.Configuration.ConfigurationManager.AppSettings["IP"];
            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }

            var result = Authtoken.checkToken(token);
            if (result == true)
            {

                if (driverm.base64image == null)
                {



                    string pic = driverm.profilePic;
                    driverm.profilePic = pic.Replace(IP, "");
                    objDriverDl.updateProfile(driverm);
                    dt = objDriverDl.getDriverbyuserID(driverm);

                    foreach (DataRow row in dt.Rows)
                    {
                        string url = dt.Rows[0]["profilePic"].ToString();

                        //need to set value to NewColumn column
                        row["profilePic"] = IP + url;

                    }




                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "Your profile Updated successfully", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;
                }
                else
                {


                    string baseencode = driverm.base64image;
                    // Convert Base64 String to byte[]
                    byte[] imageBytes = Convert.FromBase64String(baseencode);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    // Convert byte[] to Image
                    string filename = "/uploads/images/profilepics/" + Authtoken.GeneratePin() + AuthorizationToken.GetTimestamp(DateTime.Now) + ".png";
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(HttpContext.Current.Server.MapPath(filename), System.Drawing.Imaging.ImageFormat.Png);
                    driverm.profilePic = filename;
                    objDriverDl.updateProfile(driverm);
                    dt = objDriverDl.getDriverbyuserID(driverm);

                    foreach (DataRow row in dt.Rows)
                    {
                        string url = dt.Rows[0]["profilePic"].ToString();

                        //need to set value to NewColumn column
                        row["profilePic"] = IP + url;

                    }

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel()
     {
         message = "Your profile Updated successfully",
         output = dt,
         statuscode = Convert.ToInt16(HttpStatusCode.OK)
     });
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
        [Route("driver/tripEmployeelist")]
        public HttpResponseMessage tripEmployeelist([FromBody] DriverModel driverm)
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


                dt = objDriverDl.GetemployeesForTrip(driverm);



                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                     new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }

            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [HttpPost]
        [Route("driver/routeList")]
        public HttpResponseMessage routeList([FromBody]RouteAssighnmentModel objRoutenamesModel)
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


                dt = objRouteAssignmentDL.GeroutesforDriver(objRoutenamesModel);



                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                     new ResponseModel() { message = "ok successful", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }

            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [HttpPost]
        [Route("driver/updatePresentLocation")]
        public HttpResponseMessage updatePresentLocation([FromBody]DriverModel driverm)
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

                objDriverDl.updatePresentlocation(driverm);


                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                     new ResponseModel() { message = "your Location Updated Successfully", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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

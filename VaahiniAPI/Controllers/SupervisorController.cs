using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.Models;
using VaahiniAPI.DAL;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web;


namespace VaahiniAPI.Controllers
{

    public class SupervisorController : ApiController
    {
        AuthorizationToken Authtoken = new AuthorizationToken();
        SupervisorDL objSupervisorDL = new SupervisorDL();
        RouteAssignmentDL objRouteAssignmentDL = new RouteAssignmentDL();
        string token, userId,IP;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable(), dt2;
        DataSet ds;

        [HttpPost]
        [Route("supervisor/updateroute/employee_List")]

        public HttpResponseMessage employeeList([FromBody]RouteAssighnmentModel objRouteAssighnmentModel)
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

                dt = objSupervisorDL.getEmployesbyRoute(objRouteAssighnmentModel);

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
        [Route("supervisor/GetRoutes")]

        public HttpResponseMessage GetRoutes()
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

                dt = objRouteAssignmentDL.routeDetails();

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
        [Route("supervisor/updateroute/addemployee")]
        public HttpResponseMessage addemployee([FromBody]RouteAssighnmentModel objRouteAssighnmentModel)
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

                int result1 = objSupervisorDL.addemployeetoroute(objRouteAssighnmentModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "Employee Location added successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }
        [HttpPost]
        [Route("supervisor/updateroute/removeemployee")]
        public HttpResponseMessage removeemployee([FromBody]RouteAssighnmentModel objRouteAssighnmentModel)
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

                objSupervisorDL.removeemployeetoroute(objRouteAssighnmentModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "Employee Location removed successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }
        [HttpPost]
        [Route("supervisor/updateassingedroute")]
        public HttpResponseMessage updateroute([FromBody]RouteAssighnmentModel[] objRouteAssighnmentModel)
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
                var list = objRouteAssighnmentModel;
                for (int i = 0; i < objRouteAssighnmentModel.Length; i++)
                {
                    objSupervisorDL.updateemployeetoroute(objRouteAssighnmentModel[i]);

                }

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "Employee list updated successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }


        [Route("supervisor/trackcabs")]
        public HttpResponseMessage trackcabs([FromBody]RouteAssighnmentModel objRouteAssighnmentModel)
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
                DataSet ds = new DataSet();

                dt = objRouteAssignmentDL.getfemaleroutes();
                dt1 = objRouteAssignmentDL.getstartedroutes();
                dt2 = objRouteAssignmentDL.getidleroutes();

                ds.Merge(dt);
                ds.Merge(dt1);
                ds.Merge(dt2);
                ds.Tables[0].TableName = "femalecabs";
                ds.Tables[1].TableName = "startedcabs";
                ds.Tables[2].TableName = "idlecabs";
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
               new ResponseModel() { message = "ok successfull", output = ds, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }

        [HttpPost]
        [Route("supervisor/updateProfile")]
        public HttpResponseMessage UpdateProfile([FromBody] SupervisorModel objSupervisorModel)
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

                if (objSupervisorModel.base64image == null)
                {
                   string pic = objSupervisorModel.profilePic;
                    objSupervisorModel.profilePic = pic.Replace(IP, "");
                    objSupervisorDL.updateProfile(objSupervisorModel);
                    dt = objSupervisorDL.selectbyUserid(objSupervisorModel);

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

                  string baseencode = objSupervisorModel.base64image;
                    // Convert Base64 String to byte[]
                    byte[] imageBytes = Convert.FromBase64String(baseencode);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    // Convert byte[] to Image
                    string filename = "/uploads/images/profilepics/" + Authtoken.GeneratePin() + AuthorizationToken.GetTimestamp(DateTime.Now) + ".png";
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(HttpContext.Current.Server.MapPath(filename), System.Drawing.Imaging.ImageFormat.Png);
                    objSupervisorModel.profilePic = filename;
                    objSupervisorDL.updateProfile(objSupervisorModel);
                    dt = objSupervisorDL.selectbyUserid(objSupervisorModel);

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

    }
}

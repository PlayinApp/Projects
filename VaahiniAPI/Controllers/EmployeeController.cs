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
using System.Globalization;
using System.Xml;

namespace VaahiniAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDL objemployeeDL = new EmployeeDL();
        LoginModel objloginModel = new LoginModel();
        schedulecabDL objschedulecabDL = new schedulecabDL();
        Sharecab objSharecabDL = new Sharecab();
        LoginDL objLoginDL = new LoginDL();
        string token, userId,IP, apiKey, emplatlong, driverlatlong, url;
        int ShareCabId;
        AuthorizationToken Authtoken = new AuthorizationToken();
        DataTable dt = new DataTable(), dt1, dt2,dt3;
      
        /*      ---------------------------------------------------------
         *                     create Employee
         *      ---------------------------------------------------------   
         */
        [HttpPost]
        [Route("supervisor/create_Employee")]
        public HttpResponseMessage CreateEmployee([FromBody] EmployeeModel objEmployee)
        {

            //token from user
            var token = objEmployee.token;
            //checking Token
            var result = Authtoken.checkToken(token);
            if (result == true)
            {


                var Mobileexist = Authtoken.checkmobile(objEmployee.mobile);
                if (Mobileexist == false)
                {
                    //-----------------------------------------------------------------------------          
                    //         |> Inserting Employee Details <|
                    //-------------------------------------------------------------------------------
                    dt = objemployeeDL.getEmployescount();
                    objEmployee.pin = Authtoken.GeneratePin();
                    objEmployee.mobile = objEmployee.mobile;
                    objEmployee.token = Authtoken.genarateToken();
                    objEmployee.userId = Authtoken.genarateUserId();
                    //objEmployee.empId = Convert.ToInt16(dt.Rows[0]["empcount"].ToString())+1;
                    objEmployee.usertype = "employee";
                    //objemployeeDL.insert_loginDetails(objloginModel);
                    //-------------------------------------------------------------------------------
                    //                |> Inserting Login Details <|
                    //-------------------------------------------------------------------------------
                    objEmployee.useridfk = Authtoken.usercount() + 1;
                    objemployeeDL.insert_EmployeeDetails(objEmployee);

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
         new ResponseModel() { message = "Employee created sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK),error=true });
                return resp;

            }


        }
        /*      ---------------------------------------------------------
          *                       |> Employee list >|
          *     ---------------------------------------------------------   
          */
        [HttpPost]
        [Route("supervisor/employee_List")]
        public HttpResponseMessage EmployeeList([FromBody] EmployeeModel objEmployee)
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

                dt = objemployeeDL.getEmployesbyshift(objEmployee);

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


        /*      ---------------------------------------------------------
          *           |>  Employee Pickup Location <|
          *     ---------------------------------------------------------   
          */
        [HttpPost]
        [Route("employee/getPickupLocation")]
        public HttpResponseMessage GetPickupLocation([FromBody] PickuplocModel objPickuplocModel)
        {

            var re = Request;
            var headers = re.Headers;

            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            //token from user

            var result = Authtoken.checkToken(token);
            if (result == true)
            {
                if (objPickuplocModel.idindex == 0)
                {
                    userId = objPickuplocModel.userId;
                    dt = objLoginDL.selectbyUserId(userId);
                    int useridfk = Convert.ToInt16(dt.Rows[0]["id"].ToString());
                    dt1 = objemployeeDL.getindexcount(userId);
                    objPickuplocModel.idindex = Convert.ToInt16(dt1.Rows[0]["count"].ToString()) + 1;
                    objPickuplocModel.userid = useridfk;
                    objemployeeDL.getPickuplocation(objPickuplocModel);

                    dt2 = objemployeeDL.getPickupLocationbyuserId(userId);

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
         new ResponseModel() { message = "Pickup Location Added  sucessfully", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;
                }

                else
                {

                    objemployeeDL.updatePickuplocation(objPickuplocModel);
                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                            new ResponseModel() { message = "Pickup Location Updated  sucessfully", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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
    [Route("employee/getEmployeelocations")]
    public HttpResponseMessage GetEmployeelocations([FromBody] PickuplocModel objPickuplocModel) {

        var re = Request;
        var headers = re.Headers;

        if (headers.Contains("token"))
        {
            token = headers.GetValues("token").First();
        }
        var result = Authtoken.checkToken(token);

        if (result == true)
        {

                userId = objPickuplocModel.userId;
                dt2 = objemployeeDL.getPickupLocationbyuserId(userId);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "ok sucessful", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;

            }


        else
        {

            var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
            return resp;

        }


    }


    [HttpPost]
    [Route("employee/deleteEmployeelocation")]
    public HttpResponseMessage DeleteEmployeelocations([FromBody] PickuplocModel objPickuplocModel)
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


                objemployeeDL.deletePickuplocation(objPickuplocModel);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "location Deleted sucessfully",  statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;

            }


            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [HttpPost]
        [Route("employee/getWorkStatus_list")]
        public HttpResponseMessage GetWorkStatusList()
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

                dt = objemployeeDL.getworkstatus();

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
        [Route("employee/updateWorkstatus")]
        public HttpResponseMessage updateWorkStatus([FromBody] EmployeeModel objEmployee)
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
                objemployeeDL.updateempworkstatus(objEmployee);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "ok successful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK),error=true });
                return resp;

            }


        }

        [HttpPost]
        [Route("employee/updateProfile")]
        public HttpResponseMessage UpdateProfile([FromBody] EmployeeModel objEmployee)
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

                if (objEmployee.base64image == null)
                {



                    string pic = objEmployee.profilePic;
                    objEmployee.profilePic = pic.Replace(IP, "");
                    objemployeeDL.updeempprofile(objEmployee);
                    dt = objemployeeDL.getEmployesbyUserID(objEmployee);

                    foreach (DataRow row in dt.Rows)
                    {
                        string url = dt.Rows[0]["profilePic"].ToString();

                        //need to set value to NewColumn column
                        row["profilePic"] = IP + url;

                    }




                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "Your profile Updated successfully",output=dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;
                }
                else
                {

               
                string baseencode = objEmployee.base64image;
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(baseencode);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                string filename = "/uploads/images/profilepics/"+Authtoken.GeneratePin() + AuthorizationToken.GetTimestamp(DateTime.Now)+".png";
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                image.Save(HttpContext.Current.Server.MapPath(filename), System.Drawing.Imaging.ImageFormat.Png);
                objEmployee.profilePic = filename;
                objemployeeDL.updeempprofile(objEmployee);
                dt = objemployeeDL.getEmployesbyUserID(objEmployee);

                    foreach (DataRow row in dt.Rows)
                    {
                        string url = dt.Rows[0]["profilePic"].ToString();
                       
                        //need to set value to NewColumn column
                        row["profilePic"] = IP+ url;

                    }

                    var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel(){
         message = "Your profile Updated successfully",output=dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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
        [Route("employee/updatePresentLocation")]
        public HttpResponseMessage UpdatePresentLocation([FromBody] EmployeeModel objEmployee)
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
                objemployeeDL.updatePresentlocation(objEmployee);

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "Location updated Succesfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }



        [HttpPost]
        [Route("employee/schedulecab/request")]
        public HttpResponseMessage CabRequest([FromBody] scheduleCabModel objshareCabModel)
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
                string date = Convert.ToString(objshareCabModel.requestdate);
                
                int schedulecabid =  objschedulecabDL.insert_request(objshareCabModel);

                
                objshareCabModel.schedulecabid = schedulecabid;

                dt = objschedulecabDL.getresponses(objshareCabModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "ok successfull",output=dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [HttpPost]
        [Route("employee/schedulecab/getresponse")]
        public HttpResponseMessage GetResponses([FromBody] scheduleCabModel objshareCabModel)
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

               dt= objschedulecabDL.getresponses(objshareCabModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "ok successfull",output=dt ,statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }
        [HttpPost]
        [Route("employee/schedulecab/accept")]
        public HttpResponseMessage Accept([FromBody] scheduleCabModel objshareCabModel)
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

               objschedulecabDL.acceptride(objshareCabModel);
                dt = objschedulecabDL.getresponses(objshareCabModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "your ride Accepted", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

      
        [Route("employee/schedulecab/reject")]
        public HttpResponseMessage Reject([FromBody] scheduleCabModel objshareCabModel)
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

              objschedulecabDL.rejectride(objshareCabModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "your ride Rejected", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }
        [Route("employee/schedulecab/cancel")]
        public HttpResponseMessage Cancel([FromBody] scheduleCabModel objshareCabModel)
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

             objschedulecabDL.cancelride(objshareCabModel);
                dt = objschedulecabDL.getresponses(objshareCabModel);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel() { message = "your ride Cancelled",output=dt , statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [Route("employee/sharecab/request")]
        public HttpResponseMessage SharecabRequest([FromBody] ShareCabModel objShareCabModel)
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
               ShareCabId = objSharecabDL.insert_sharecab(objShareCabModel);
               objShareCabModel.sharecabid = ShareCabId;
               dt = objSharecabDL.GetResponce(objShareCabModel);
                
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
     new ResponseModel()
     {
         message = "ok successfull", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                return resp;
            }
            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }


        }

        [Route("employee/sharecab/response")]
        public HttpResponseMessage SharecabResponse([FromBody] ShareCabModel objShareCabModel)
        {
            apiKey = System.Configuration.ConfigurationManager.AppSettings["apikey"];
            DataSet ds = new DataSet();
            dt3 = objSharecabDL.GetResponce(objShareCabModel);
            if (dt3.Rows[0][4] != null) { 
            emplatlong = dt3.Rows[0]["empLatitude"].ToString() +","+ dt3.Rows[0]["empLongitude"].ToString();
            driverlatlong = dt3.Rows[0]["driverLatitude"].ToString() +","+ dt3.Rows[0]["driverLongitude"].ToString();

          url = @"https://maps.googleapis.com/maps/api/distancematrix/xml?&origins=" + driverlatlong + "&destinations=" + emplatlong + "&key=" + apiKey + "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();


                ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
            }
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables["element"].Rows[0]["status"].ToString() == "OK")
                {
                    dt = ds.Tables["distance"];

                }

                ds.Merge(dt3);
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
             new ResponseModel() { message = "your details", output = ds, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
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

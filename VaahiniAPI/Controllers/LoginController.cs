using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.Models;
using VaahiniAPI.DAL;
using System.Net.Http.Headers;
using System.Configuration;

namespace VaahiniAPI.Controllers
{
    public class LoginController : ApiController
    {
        DataTable dt = new DataTable();
     
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        LoginDL objloginDL = new LoginDL();
        AuthorizationToken objAuthorization = new AuthorizationToken();
        OTPClass objotp = new OTPClass();

        string usertype, userid, token, otp,IP;
        dynamic resp;
      
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage login([FromBody] LoginModel loginm)
        {
            IP = System.Configuration.ConfigurationManager.AppSettings["IP"];
            DataTable dt1 = new DataTable();
            var result = objAuthorization.checkToken(loginm.token);
            //for token
              dt1 = objloginDL.checkUser(loginm);
                //checking mobile and pin
                if (dt1.Rows.Count > 0)

                {
                    //Getting usertype
                 usertype = dt1.Rows[0]["userType"].ToString();
                 userid= dt1.Rows[0]["userId"].ToString();
              
                token = dt1.Rows[0]["token"].ToString();
                loginm.userId = userid;
                 result= objAuthorization.checkDevicekey(userid, loginm.devicekey);
                if (result == false) {
                    loginm.useridFK = Convert.ToInt16(dt1.Rows[0]["id"].ToString());
                    objloginDL.insert_DeicviceDetails(loginm);

                }


                dt2 =objAuthorization.usertype(usertype, dt1);

                dt2.Columns.Add("token", typeof(System.String));

                foreach (DataRow row in dt2.Rows)
                {
                    //need to set value to NewColumn column
                    row["token"] = token;
                    row["profilePic"] = IP + dt2.Rows[0]["profilePic"].ToString();



                }


                resp = Request.CreateResponse<ResponseModel>(
                                                            HttpStatusCode.OK,
                                                            new ResponseModel() { message = "login sucessfull", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                        );
                resp.Headers.Add("token",token);
               
                return resp;


                }

                else
                {

                    resp = Request.CreateResponse<ResponseModel>( HttpStatusCode.OK,
                                    new ResponseModel() { message = "Mobile or Pin Wrong",error=true, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
                    return resp;


                }

        }
        [HttpPost]
        [Route("login/forgotPassword")]
        public HttpResponseMessage forgotPassword([FromBody] LoginModel loginm)
        {
           dt = objloginDL.checkUserMobile(loginm);
            //checking mobile and pin
            if (dt.Rows.Count > 0)

            {
                //Getting usertype

                
                 otp = objotp.GenerateOTP();

                resp = Request.CreateResponse<ResponseModel>( HttpStatusCode.OK,
                                                        new ResponseModel() { message = "otp sended sucessfully", output = dt, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
              
                return resp;


            }

            else
            {

                resp = Request.CreateResponse<ResponseModel>(
                                                                   HttpStatusCode.OK,
                                                                   new ResponseModel() { message = "Mobile or Pin Wrong", statuscode = Convert.ToInt16(HttpStatusCode.OK) }    );
                return resp;


            }


        }

        [HttpPost]
        [Route("login/verifyOTP")]
        public HttpResponseMessage verifyOTP([FromBody] LoginModel loginm)
        {
            var result = objAuthorization.checkOTP(loginm);
            if (result == true) {

                resp = Request.CreateResponse<ResponseModel>( HttpStatusCode.OK,  new ResponseModel() { message = "OTP Verified successfully", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) } );
                return resp;


            }
            else


                resp = Request.CreateResponse<ResponseModel>(
                                                               HttpStatusCode.OK,
                                                               new ResponseModel() { message = "Incorrect otp", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                           );
            return resp;
        }

        [HttpPost]
        [Route("login/changePin")]
        public HttpResponseMessage changePin([FromBody] LoginModel loginm)
        {

           var result = objAuthorization.checkOldPin(loginm);
            if (result == true)
            {

                objloginDL.updatePin(loginm);

                resp = Request.CreateResponse<ResponseModel>(
                                                               HttpStatusCode.OK,
                                                               new ResponseModel() { message = "pin changed Successfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                           );
                return resp;


            }

            else {

                resp = Request.CreateResponse<ResponseModel>(
                                                               HttpStatusCode.OK,
                                                               new ResponseModel() { message = "incorrect pin", statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                           );
                return resp;


            }

        }
       
        [HttpPost]
        [Route("unique")]
        public HttpResponseMessage unique()
        {

            string id = objAuthorization.genarateUserId();

            resp = Request.CreateResponse<ResponseModel>(
                                                                    HttpStatusCode.OK,
                                                                    new ResponseModel() { message = id, statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;

        }

    }
}

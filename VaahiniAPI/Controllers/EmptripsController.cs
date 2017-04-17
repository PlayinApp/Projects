using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;

namespace VaahiniAPI.Controllers
{
    public class EmptripsController : ApiController
    {
        EmptripsDL objEmptripsDL = new EmptripsDL();

        AuthorizationToken Authtoken = new AuthorizationToken();

        LoginModel objloginModel = new LoginModel();
        LoginDL objLoginDL = new LoginDL();
        string token, userId;
     
        DataTable dt = new DataTable(), dt1, dt2;

        [Route("employee/start_Employeetrip")]
        public HttpResponseMessage createEmployeetrip([FromBody] EmptripsModel objEmptripsModel)
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

                userId = objEmptripsModel.userId;
                dt = objLoginDL.selectbyUserId(userId);
              
                objEmptripsModel.userIdfk = Convert.ToInt16(dt.Rows[0]["id"].ToString());
                objEmptripsModel.tripstatus =1;
                dt2 = objEmptripsDL.getemptripscount();
                
                dt2.Columns.Add("emptripId", typeof(System.Int32));



                int emptripId =    objEmptripsDL.insert_starttrip(objEmptripsModel);

                foreach (DataRow row in dt2.Rows)
                {
                    //need to set value to NewColumn 
                    row["emptripId"] = emptripId;

                }

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "Your trip started succesfully", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK),error=false });
                return resp;

            }


            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK),error=true });
                return resp;

            }



        }


        [Route("employee/end_Employeetrip")]
        public HttpResponseMessage endEmployeetrip([FromBody] EmptripsModel objEmptripsModel)
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

                userId = objEmptripsModel.userId;
                dt = objLoginDL.selectbyUserId(userId);

                
                objEmptripsModel.tripstatus = 2;

               
                objEmptripsDL.insert_endttrip(objEmptripsModel);
               
              
               
                
                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "Your trip ended succesfully", statuscode = Convert.ToInt16(HttpStatusCode.OK),error=false });
                return resp;

            }


            else
            {

                var resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK),error=true });
                return resp;

            }



        }
    }


}


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
    public class SosAlertController : ApiController
    {
        SosAlertsDL objSosAlertsDL = new SosAlertsDL();
        AuthorizationToken Authtoken = new AuthorizationToken();
        LoginModel objloginModel = new LoginModel();
        LoginDL objLoginDL = new LoginDL();
        string token, userId;
        dynamic  resp;
        DataTable dt = new DataTable(), dt1, dt2;

        [Route("employee/create_sosAlert")]
        public HttpResponseMessage create_sosAlert(SosAlertsModel objSosAlertsModel)
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

                userId = objSosAlertsModel.userId;
                dt = objLoginDL.selectbyUserId(userId);

                objSosAlertsModel.userIdfk = Convert.ToInt16(dt.Rows[0]["id"].ToString());
                objSosAlertsDL.insert_SosAlert(objSosAlertsModel);
               

                 resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK,
                         new ResponseModel() { message = "Your sos details saved succesfully", output = dt2, statuscode = Convert.ToInt16(HttpStatusCode.OK), error = false });
                return resp;

            }

            else
            {

                 resp = Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, new ResponseModel() { message = "UnAuthorized", statuscode = Convert.ToInt16(HttpStatusCode.OK), error = true });
                return resp;

            }

        }

    }
}

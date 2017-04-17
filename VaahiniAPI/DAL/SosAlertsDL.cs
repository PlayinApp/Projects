using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;
using System.Data;
using System.Data.SqlClient;


namespace VaahiniAPI.DAL
{
    public class SosAlertsDL
    {
        public int insert_SosAlert(SosAlertsModel objSosModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_sosalerts", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),




            new SqlParameter("@latitude",objSosModel.latitude ),
            new SqlParameter("@longitude", objSosModel.latitude),
            new SqlParameter("@address", objSosModel.address),
             new SqlParameter("@userIdFK", objSosModel.userIdfk),
              

            new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
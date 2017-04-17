using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.DAL;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{
    public class Sharecab
    {


      

        public int insert_sharecab(ShareCabModel objShareCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_sharecab", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),


                new SqlParameter("@empid",objShareCabModel.empid ),
                new SqlParameter("@presentLatitude", objShareCabModel.presentlatitude),
               new SqlParameter("@presentLongitude", objShareCabModel.presentlongitude),


            new SqlParameter("@status", 1), });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetResponce(ShareCabModel objShareCabModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_sharecab", new SqlParameter[]
        {


             new SqlParameter("@empid",objShareCabModel.empid ),
                new SqlParameter("@sharecabid",objShareCabModel.sharecabid ),
                new SqlParameter("@Command","GETRESPONSE"),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public int AcceptbyDriver(ShareCabModel objShareCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_sharecab", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),


                new SqlParameter("@empid",objShareCabModel.empid ),
                new SqlParameter("@presentLatitude", objShareCabModel.presentlatitude),
               new SqlParameter("@presentLongitude", objShareCabModel.presentlongitude),


            new SqlParameter("@status", 1), });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
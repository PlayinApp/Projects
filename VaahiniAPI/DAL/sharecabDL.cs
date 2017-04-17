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
    public class sharecabDL
    {

        public DataTable getdrivercomplaintlist(ComplaintsModel objComplaintsModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_complaints", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTBYUSERTYPE"),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public int insert_driverComplaints()
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_complaints", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERTDRIVERCOMP"),


                new SqlParameter("complaintid", objComplaintsModel.complaintid),
                new SqlParameter("@userId", objComplaintsModel.userid),
               new SqlParameter("@others", objComplaintsModel.others),
                new SqlParameter("@status", 1), });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
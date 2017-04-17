using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{



    public class schedulecabDL
    {
        public int insert_request(scheduleCabModel objshareCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_schedulecab", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),

                new SqlParameter("@empid", objshareCabModel.empid),
                 new SqlParameter("@requestdate", objshareCabModel.requestdate),
                  new SqlParameter("@requesttime", objshareCabModel.requesttime),
                  new SqlParameter("@userid", objshareCabModel.userid),
                  new SqlParameter("@picklocationid", objshareCabModel.locationid),
                   new SqlParameter("@ridestatus", 1),
                    new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getresponses(scheduleCabModel objshareCabModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_schedulecab", new SqlParameter[]
        {

             new SqlParameter("@schedulecabid",objshareCabModel.schedulecabid),
              new SqlParameter("@empid",objshareCabModel.empid),

                new SqlParameter("@Command", "GETRESPONSE"),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public int acceptride(scheduleCabModel objscheduleCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_schedulecab", new SqlParameter[]
        {


                new SqlParameter("@Command","ACCEPTBYUSER"),



                    new SqlParameter("@empid",objscheduleCabModel.empid),

                    new SqlParameter("@schedulecabid", objscheduleCabModel.schedulecabid),







                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int rejectride(scheduleCabModel objscheduleCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_schedulecab", new SqlParameter[]
        {


                new SqlParameter("@Command","REJECTBYUSER"),



                    new SqlParameter("@empid",objscheduleCabModel.empid),

                    new SqlParameter("@schedulecabid", objscheduleCabModel.schedulecabid),







                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int cancelride(scheduleCabModel objscheduleCabModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_schedulecab", new SqlParameter[]
        {


                new SqlParameter("@Command","CANCELBYUSER"),



                    new SqlParameter("@empid",objscheduleCabModel.empid),

                    new SqlParameter("@schedulecabid", objscheduleCabModel.schedulecabid),







                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
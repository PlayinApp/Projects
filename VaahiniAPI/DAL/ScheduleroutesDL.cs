using System;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{
    public class ScheduleroutesDL
    {
        public int insert_scheduleroutes(ScheduleroutesModel objscheduleroutes)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_scheduleroutes", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),

                new SqlParameter("@routeId", objscheduleroutes.routeid),
                new SqlParameter("@driverid", objscheduleroutes.driverid),
                new SqlParameter("@vehicleId", objscheduleroutes.vehicleId),
              
                new SqlParameter("@status", 1), });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable getscheduleroutes()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_scheduleroutes", new SqlParameter[]
        {



                new SqlParameter("@Command","GETSCHEDULEROUTES"),
               


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
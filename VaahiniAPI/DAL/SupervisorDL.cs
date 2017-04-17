using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{


    public class SupervisorDL
    {
        public DataTable getEmployesbyRoute(RouteAssighnmentModel objRouteAssighnmentModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command","GETROUTEUPDATE"),
                new SqlParameter("@shiftid", objRouteAssighnmentModel.shiftid),
                 new SqlParameter("@routeid", objRouteAssighnmentModel.routeid),




        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public int addemployeetoroute(RouteAssighnmentModel objRouteAssighnmentModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_routeallocation", new SqlParameter[]
        {


                new SqlParameter("@Command","ADDASSIGNSTATUS"),


                 new SqlParameter("@routeid",objRouteAssighnmentModel.routeid),
                new SqlParameter("@empid", objRouteAssighnmentModel.empid),

                new SqlParameter("@shiftid", objRouteAssighnmentModel.shiftid),
               
                       
                          new SqlParameter("@status", 1)
                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int removeemployeetoroute(RouteAssighnmentModel objRouteAssighnmentModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_routeallocation", new SqlParameter[]
        {


                new SqlParameter("@Command","REMOVEASSIGNSTATUS"),


                 new SqlParameter("@routeid",objRouteAssighnmentModel.routeid),
                new SqlParameter("@empid", objRouteAssighnmentModel.empid),

                new SqlParameter("@shiftid", objRouteAssighnmentModel.shiftid),

                          new SqlParameter("@status", 1)
                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateemployeetoroute(RouteAssighnmentModel objRouteAssighnmentModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_routeallocation", new SqlParameter[]
        {


                new SqlParameter("@Command","UPDATEASSIGNROUTE"),

                 new SqlParameter("@actionstatus", objRouteAssighnmentModel.actionstatus),

                 new SqlParameter("@routeid",objRouteAssighnmentModel.routeid),
                new SqlParameter("@empId", objRouteAssighnmentModel.empid),

                new SqlParameter("@shiftid", objRouteAssighnmentModel.shiftid),
               

                          
                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int updateProfile(SupervisorModel objSupervisorModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_employee", new SqlParameter[]
        {


                new SqlParameter("@Command","SUPERVISORPROFILE"),
                new SqlParameter("@mobile", objSupervisorModel.mobile),
                new SqlParameter("@email", objSupervisorModel.email),
                new SqlParameter("@emergencycontact",objSupervisorModel.emergencyContact),
                new SqlParameter("@profilePic", objSupervisorModel.profilePic),
                new SqlParameter("@userId", objSupervisorModel.userid),

                 });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable selectbyUserid(SupervisorModel objSupervisorModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTBYUSERIDFORSP"),
                new SqlParameter("@userId", objSupervisorModel.userid),
                


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
    }
}
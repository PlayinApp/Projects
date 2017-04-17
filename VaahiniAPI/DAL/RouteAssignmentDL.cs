using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{
    public class RouteAssignmentDL
    {

        public int insert_Assighnment(RouteAssighnmentModel objRoutenamesModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_routeallocation", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),
                new SqlParameter("@routeid", objRoutenamesModel.routeid),
                new SqlParameter("@empId", objRoutenamesModel.empid),
                new SqlParameter("@shiftid", objRoutenamesModel.shiftid),

                new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int insert_Routenames(RouteAssighnmentModel objRoutenamesModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_routeallocation", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERTROUTE"),
                new SqlParameter("@routeName", objRoutenamesModel.routeName),
                

                new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable getAssighnmentroutes()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTALL")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DataTable getroutes(string routeName)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETROUTE"),
                new SqlParameter("@routeName",routeName ),
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public DataTable getrouteslist()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETROUTELIST"),
                
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public DataTable routeDetails()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETROUTESDETAILS"),
               
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public DataTable getrouteCount()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETROUTECOUNT"),
                
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public DataTable getfemaleroutes()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETFEMALEROUTES"),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DataTable getstartedroutes()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETSTARTEDROUTES"),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DataTable getidleroutes()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETIDLEROUTES"),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public DataTable GeroutesforDriver(RouteAssighnmentModel objRoutenamesModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_routeallocation", new SqlParameter[]
        {

              new SqlParameter("@Command", "GETROUTESFORDRIVER"),
             new SqlParameter("@driverid", objRoutenamesModel.driverid),
              

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
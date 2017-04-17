using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{
    public class DrivertripsDL
    {

        public int insert_starttrip(DriverTripsModel objDrivertripsModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_drivertrips", new SqlParameter[]
        {


                new SqlParameter("@Command","STARTTRIP"),




            new SqlParameter("@driverid", objDrivertripsModel.driverid),
            new SqlParameter("@startLatitude", objDrivertripsModel.startlatitude),
            new SqlParameter("@startLongitude", objDrivertripsModel.startlongititude),
            new SqlParameter("@triptype", objDrivertripsModel.triptype),
            new SqlParameter("@tripstatus",1),
            new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert_endttrip(DriverTripsModel objdrivertripsModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_drivertrips", new SqlParameter[]
        {


            new SqlParameter("@Command","ENDTRIP"),
            new SqlParameter("@driverid", objdrivertripsModel.driverid),
            new SqlParameter("@driverTripId", objdrivertripsModel.drivertripid),
            new SqlParameter("@endLatitude", objdrivertripsModel.endlatitude),
            new SqlParameter("@endLongitude", objdrivertripsModel.endlongititude),
             new SqlParameter("@routeId", objdrivertripsModel.routeid),
            new SqlParameter("@tripstatus",2),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getdrivertrips()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_drivertrips", new SqlParameter[]
        {

                new SqlParameter("@Command", "SELECTALL")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
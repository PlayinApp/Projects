using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace VaahiniAPI.DAL
{
    public class shiftDL
    {

        public int insert_ShiftDetails(ShiftModel objShiftModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_shift", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),
            

            
           
            new SqlParameter("@shiftname", objShiftModel.shiftName),
            new SqlParameter("@starttime", objShiftModel.starttime),
            new SqlParameter("@endtime", objShiftModel.endtime),

            new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getshifts()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_shift", new SqlParameter[]
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
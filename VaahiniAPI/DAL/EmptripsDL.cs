using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace VaahiniAPI.DAL
{
    public class EmptripsDL
    {


        public int insert_starttrip(EmptripsModel objEmptripsModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_emptrips", new SqlParameter[]
        {


            new SqlParameter("@Command","STARTTRIP"),
           
            new SqlParameter("@startLatitude", objEmptripsModel.startLatitude),
            new SqlParameter("@startLongitude", objEmptripsModel.startLongititude),
            new SqlParameter("@startAddress", objEmptripsModel.startAddress),
            new SqlParameter("@triptype", objEmptripsModel.triptype),
            new SqlParameter("@tripstatus", objEmptripsModel.tripstatus),
            new SqlParameter("@useridFk", objEmptripsModel.userIdfk),
            new SqlParameter("@usertype", objEmptripsModel.userType),
            new SqlParameter("@status",1),
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert_endttrip(EmptripsModel objEmptripsModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_emptrips", new SqlParameter[]
        {


                new SqlParameter("@Command","ENDTRIP"),



             new SqlParameter("@emptripId", objEmptripsModel.emptripId),
          
            new SqlParameter("@endLatitude", objEmptripsModel.endLatitude),
            new SqlParameter("@endLongitude", objEmptripsModel.endLongitude),
             new SqlParameter("@isemergencystop", objEmptripsModel.isemergencystop),
              new SqlParameter("@endAddress", objEmptripsModel.endAddress),
               new SqlParameter("@tripstatus", objEmptripsModel.tripstatus),

          



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getemptripscount()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_emptrips", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTCOUNT")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
    }
}
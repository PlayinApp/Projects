using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;
using System.Data;

using System.Data.SqlClient;

namespace VaahiniAPI.DAL
{
    public class VehicleDL
    {

        public int insert_vehicleDetails(VehicleModel objvehicleModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_vehicle", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),
                new SqlParameter("@vehNameModel", objvehicleModel.vehNameModel),
                new SqlParameter("@vehicleRegNo", objvehicleModel.vehicleRegNo),
                new SqlParameter("@vehicleCondition", objvehicleModel.vehicleCondition),
                new SqlParameter("@isContainFirstAID", objvehicleModel.isContainFirstAID),
                new SqlParameter("@isContainAirbags", objvehicleModel.isContainAirbags),
                new SqlParameter("@isContainsFireControll", objvehicleModel.isContainsFireControll),
                new SqlParameter("@isVehicleowned", objvehicleModel.isVehicleowned),
                new SqlParameter("@ownername", objvehicleModel.ownername),
                new SqlParameter("@ownerNumder", objvehicleModel.ownerNumder),
                new SqlParameter("@ownerAddress", objvehicleModel.ownerAddress),
                new SqlParameter("@inspectedBy", objvehicleModel.inspectedBy),

                new SqlParameter("@vehicleType", objvehicleModel.vehicletype),

                new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataTable getVehicles()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_vehicle", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTALL"),

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
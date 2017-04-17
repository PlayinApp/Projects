using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VaahiniAPI.Models;
using System.Data;

using System.Data.SqlClient;

namespace VaahiniAPI.DAL
{
    public class DriverDL
    {
        public int insert_DriverDetails(DriverModel objdriverModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_driver", new SqlParameter[]
        {
            new SqlParameter("@Command","INSERT"),
            new SqlParameter("@name", objdriverModel.name),
            new SqlParameter("@email", objdriverModel.email),
            new SqlParameter("@age", objdriverModel.age),
            new SqlParameter("@emergencyContact", objdriverModel.emergencyContact),
            new SqlParameter("@panno", objdriverModel.panno),
            new SqlParameter("@aadharno", objdriverModel.aadharNo),
            new SqlParameter("@experience", objdriverModel.experience),
            new SqlParameter("@currentAddr", objdriverModel.currentAddr),
            new SqlParameter("@permanentAaddr", objdriverModel.permanentAaddr),
            new SqlParameter("@licenceno", objdriverModel.licenceno),
            new SqlParameter("@fromdateTodate", objdriverModel.fromdateTodate),
            new SqlParameter("@transportCompany", objdriverModel.transportCompany),
            new SqlParameter("@vehicleno", objdriverModel.vehicleno),
            new SqlParameter("@profilePic", objdriverModel.profilePic),
            new SqlParameter("@bloodGroup", objdriverModel.bloodGroup),
            new SqlParameter("@eyeSight", objdriverModel.eyeSight),
            new SqlParameter("@breathTest", objdriverModel.breathTest),
            new SqlParameter("@lifeInsurance", objdriverModel.lifeInsurance),
             new SqlParameter("@isComsumeAlcohal", objdriverModel.isComsumeAlcohal),
            new SqlParameter("@isSmoke", objdriverModel.isSmoke),
            new SqlParameter("@physicalInjuries", objdriverModel.physicalInjuries),
            new SqlParameter("@otherhealthIssues", objdriverModel.otherhealthIssues),
            new SqlParameter("@driverDeviceid", objdriverModel.deviceId),

            new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateProfile(DriverModel objdriverModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_driver", new SqlParameter[]
        {
            new SqlParameter("@Command","UPDATEDRIVERPROFILE"),
            new SqlParameter("@name", objdriverModel.name),
            new SqlParameter("@email", objdriverModel.email),
             new SqlParameter("@mobile", objdriverModel.mobile),
            new SqlParameter("@age", objdriverModel.age),
             new SqlParameter("@useridPK", objdriverModel.userId),
            new SqlParameter("@emergencyContact", objdriverModel.emergencyContact),
            new SqlParameter("@profilePic", objdriverModel.profilePic),
            



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatePresentlocation(DriverModel objdriverModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_driver", new SqlParameter[]
        {
            new SqlParameter("@Command","UPDATELOCATION"),
            new SqlParameter("@presentLatitude", objdriverModel.presentLatitude),
            new SqlParameter("@presentLongitude", objdriverModel.presentLongitude),
            new SqlParameter("@presentAddress", objdriverModel.presentAddress),
             new SqlParameter("@driverid", objdriverModel.driverid),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int insert_loginDetails(LoginModel objloginModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_login", new SqlParameter[]
        {
            new SqlParameter("@Command","INSERTDRIVERLOGIN"),
            new SqlParameter("@mobile", objloginModel.mobile),
            new SqlParameter("@pin", objloginModel.pin),
            new SqlParameter("@usertype", objloginModel.userType),
            new SqlParameter("@driverid", objloginModel.driverId),
            new SqlParameter("@userId", objloginModel.userId),
            new SqlParameter("@token", objloginModel.token),
            new SqlParameter("@status",1),
        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetemployeesForTrip(DriverModel objdriverModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_driver", new SqlParameter[]
        {



                new SqlParameter("@Command", "GETTRIPEMPLIST"),
                new SqlParameter("@routeId", objdriverModel.routeid)

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public DataTable getDrivers()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_driver", new SqlParameter[]
        {


              
                new SqlParameter("@Command", "SELECTALL")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getDriverscount()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_driver", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTCOUNT")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getDriverbyID(int driverid )
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_driver", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTALLBYID"),
                  new SqlParameter("@driverid", driverid)


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getDriverbyuserID(DriverModel objdriverModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_driver", new SqlParameter[]
        {



                new SqlParameter("@Command", "SELECTBYUSERID"),
                  new SqlParameter("@useridPK", objdriverModel.userId)


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
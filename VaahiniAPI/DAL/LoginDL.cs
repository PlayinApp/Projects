using System;
using System.Data;
using VaahiniAPI.Models;
using System.Data.SqlClient;

namespace VaahiniAPI.DAL
{
    public class LoginDL
    {

        public DataTable checkToken(string token)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {


                new SqlParameter("@token", token),
                new SqlParameter("@Command", "CHECKTOKEN")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable checkMobile(string Mobile)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {


                new SqlParameter("@Mobile", Mobile),
                new SqlParameter("@Command", "CHECKMOBILE")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataTable userCount()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {


               
                new SqlParameter("@Command", "GETUSERCOUNT")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataTable checkUser(LoginModel Objlogin)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {

             new SqlParameter("@mobile", Objlogin.mobile),
                new SqlParameter("@pin", Objlogin.pin),
                 new SqlParameter("@usertype", Objlogin.userType),
                new SqlParameter("@Command", "CHECKUSER")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        
        public DataTable checkOTP(LoginModel Objlogin)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {

             new SqlParameter("@mobile", Objlogin.mobile),
                new SqlParameter("@otp", Objlogin.OTP),
                new SqlParameter("@Command", "CHECKOTP")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public DataTable checkDevicekey(string userId,string devicekey)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_devices", new SqlParameter[]
        {

             new SqlParameter("@userIdPK", userId),

              new SqlParameter("@devicekey",devicekey),
                new SqlParameter("@Command", "CHECKDEVICEKEY")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public DataTable selectbyUserId(string userId)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {

             new SqlParameter("@userId", userId),

                new SqlParameter("@Command", "SELECTBYUSERID")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public DataTable checkoldPin(LoginModel loginm)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {

             new SqlParameter("@userId",loginm.userId ),
             new SqlParameter("@pin",loginm.pin ),
                new SqlParameter("@Command", "CHECKOLDPIN"),
                 


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable checkUserMobile(LoginModel Objlogin)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {

             new SqlParameter("@mobile", Objlogin.mobile),

                new SqlParameter("@Command", "CHECKMOBILE")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getSuperDetails(int spId)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_login", new SqlParameter[]
        {


                new SqlParameter("@superVisorId", spId),
                new SqlParameter("@Command", "GETSUPERVISOR")

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        
        public int insert_DeicviceDetails(LoginModel Objlogin)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_devices", new SqlParameter[]
        {


             new SqlParameter("@Command","INSERT"),
             new SqlParameter("@deviceOs", Objlogin.deviceOs),
             new SqlParameter("@deviceOsVersion", Objlogin.deviceOsVersion),
              new SqlParameter("@deviceModel", Objlogin.deviceModel),
             new SqlParameter("@devicekey", Objlogin.devicekey),
              new SqlParameter("@userIdFK", Objlogin.useridFK),
             new SqlParameter("@status",1),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updatePin(LoginModel Objlogin)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_login", new SqlParameter[]
        {


                new SqlParameter("@Command","CHANGEPIN"),
             new SqlParameter("@userId", Objlogin.userId),
              new SqlParameter("@pin", Objlogin.newPin)


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
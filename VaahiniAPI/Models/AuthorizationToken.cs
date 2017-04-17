using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VaahiniAPI.DAL;

namespace VaahiniAPI.Models
{
    public class AuthorizationToken
    {
        /// <summary>
        /// Object Creation
        /// </summary>
        DataTable dt = new DataTable();
        LoginDL objloginDL = new LoginDL();
        LoginModel objloginModel = new LoginModel();
        EmployeeDL objEmployeeDL = new EmployeeDL();
        DriverDL objDriverDL = new DriverDL();
        LoginDL objLoginDL = new LoginDL();
        /// <summary>
        /// checking token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool checkToken(string token)
        {

           dt= objloginDL.checkToken(token);

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;





        }
        public bool checkmobile(string Mobile)
        {

            dt = objloginDL.checkMobile(Mobile);

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;





        }
        public bool checkOTP(LoginModel objloginModel)
        {

            dt = objloginDL.checkOTP(objloginModel);

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;





        }
        public bool checkDevicekey(string userId,string devicekey)
        {

            dt = objloginDL.checkDevicekey(userId, devicekey);

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;





        }
        public bool checkOldPin(LoginModel loginm)
        {

            dt = objloginDL.checkoldPin(loginm);

            if (dt.Rows.Count > 0)
            {


                return true;


            }
            else

                return false;





        }

        public string  genarateUserId()
        {

            Guid guid = Guid.NewGuid();
            string uniqueID = guid.ToString();
            string timeStamp = GetTimestamp(DateTime.Now);


              return uniqueID+timeStamp;

        }
        public string genarateToken()
        {

            Guid guid = Guid.NewGuid();
            string uniqueID = guid.ToString();
            return uniqueID;

        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// Getting user details by usertype
        /// </summary>
        /// <param name="usertype"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable usertype(string usertype,DataTable dt) {


            DataTable dt1 = new DataTable();

                // Begin the switch.
                switch (usertype)
                {
                    case "supervisor": {


                        int spid = Convert.ToInt16(dt.Rows[0]["supervisorId"].ToString());

                        dt1 = objloginDL.getSuperDetails(spid);
                        return dt1;
                    }
                    case "employee": {

                        int empid = Convert.ToInt16(dt.Rows[0]["empid"].ToString());

                        dt1 = objEmployeeDL.getEmployesbyID(empid);
                        return dt1;
                    }
                    case "driver":
                        {
                        int driverid = Convert.ToInt16(dt.Rows[0]["driverid"].ToString());

                        dt1= objDriverDL.getDriverbyID(driverid);
                        return dt1;
                        }
                   
                    
                    default:
                    // You can use the default case.
                    return dt;
                }
            



        }

        public int usercount()
        {

            dt = objloginDL.userCount();
            int count =Convert.ToInt16(dt.Rows[0]["usercount"].ToString());

            return count; // Begin the switch.
        }

        public string GeneratePin()
        {


            string numbers = "1234567890";

            string characters = numbers;

            int length = 6;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }


            return otp;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using VaahiniAPI.Models;

namespace VaahiniAPI.DAL
{
    public class EmployeeDL
    {


        public int insert_EmployeeDetails(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_employee", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),
               new SqlParameter("@name", objemployeeModel.name),
                new SqlParameter("@mobile", objemployeeModel.mobile),
                new SqlParameter("@email", objemployeeModel.email),
                new SqlParameter("@pin", objemployeeModel.pin),
                new SqlParameter("@usertype", objemployeeModel.usertype),
              

                new SqlParameter("@token", objemployeeModel.token),

                new SqlParameter("@userId", objemployeeModel.userId),
                 new SqlParameter("@userfk", objemployeeModel.useridfk),

                new SqlParameter("@presentAddress", objemployeeModel.presentAddress),
                new SqlParameter("@landmark", objemployeeModel.landmark),
                new SqlParameter("@gender", objemployeeModel.gender),
                new SqlParameter("@companyBranch", objemployeeModel.companybranch),
                new SqlParameter("@pickuplocation", objemployeeModel.pickuplocation),
                
                new SqlParameter("@profilePic", objemployeeModel.profilePic),
                new SqlParameter("@deviceId", objemployeeModel.deviceId),
               
                new SqlParameter("@Age", objemployeeModel.Age),
                new SqlParameter("@shift", objemployeeModel.shift),
                 
                new SqlParameter("@status", 1), });





           
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


                new SqlParameter("@Command","INSERTEMPLOGIN"),

                new SqlParameter("@mobile", objloginModel.mobile),
                new SqlParameter("@pin", objloginModel.pin),
                new SqlParameter("@usertype", objloginModel.userType),
                new SqlParameter("@empid", objloginModel.empId),
                
                new SqlParameter("@token", objloginModel.token),

                new SqlParameter("@userId", objloginModel.userId),
               
                new SqlParameter("@status", 1), });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getPickuplocation(PickuplocModel objPickuplocModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_pickuplocation", new SqlParameter[]
        {


                new SqlParameter("@Command","INSERT"),


                 new SqlParameter("@pickuplat",objPickuplocModel.pickuplat),
                new SqlParameter("@pickuplong", objPickuplocModel.pickuplong),

                new SqlParameter("@pickupaddress", objPickuplocModel.pickupaddress),
                new SqlParameter("@placename",objPickuplocModel.placename ),
                    new SqlParameter("@userid", objPickuplocModel.userid),
                        new SqlParameter("@idindex", objPickuplocModel.idindex),
                          new SqlParameter("@status", 1)
                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatePresentlocation(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_employee", new SqlParameter[]
        {


                new SqlParameter("@Command","UPDATELOCATION"),


                 new SqlParameter("@presentAddress",objemployeeModel.presentAddress),
                new SqlParameter("@presentLatitude", objemployeeModel.presentLatitude),

                new SqlParameter("@presentLongitude", objemployeeModel.presentLongitude),
               
                    
                        new SqlParameter("@empId", objemployeeModel.empId)

                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatePickuplocation(PickuplocModel objPickuplocModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_pickuplocation", new SqlParameter[]
        {


                new SqlParameter("@Command","UPDATELOCATION"),


                 new SqlParameter("@pickuplat",objPickuplocModel.pickuplat),
                new SqlParameter("@pickuplong", objPickuplocModel.pickuplong),

                new SqlParameter("@pickupaddress", objPickuplocModel.pickupaddress),
                new SqlParameter("@placename",objPickuplocModel.placename ),
                    new SqlParameter("@userid1", objPickuplocModel.userId),
                        new SqlParameter("@idindex", objPickuplocModel.idindex)
                        
                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deletePickuplocation(PickuplocModel objPickuplocModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_pickuplocation", new SqlParameter[]
        {


                new SqlParameter("@Command","DELETELOCATION"),


                
                    new SqlParameter("@userid1", objPickuplocModel.userId),
                        new SqlParameter("@idindex", objPickuplocModel.idindex)

                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateempworkstatus(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_employee", new SqlParameter[]
        {


                new SqlParameter("@Command","UPDATEEMPWORKSTATUS"),



                    new SqlParameter("@userId", objemployeeModel.userId),
                        new SqlParameter("@workstatusid", objemployeeModel.workstatusId)

                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updeempprofile(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteNonQuery_with_result("sp_employee", new SqlParameter[]
        {


                new SqlParameter("@Command","UPDATEUSERPROFILE"),



                    new SqlParameter("@userId", objemployeeModel.userId),
                   
                    new SqlParameter("@mobile", objemployeeModel.mobile),
                    
                    new SqlParameter("@presentAddress", objemployeeModel.presentAddress),
                    new SqlParameter("@emergencycontact", objemployeeModel.emergencycontact),
                   
                    new SqlParameter("@profilePic", objemployeeModel.profilePic),

                       

                 });






            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public DataTable getEmployesbyshift(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {


            
                new SqlParameter("@Command","GETEMPLOYEES"),
                new SqlParameter("@shift", objemployeeModel.shift)
               


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getEmployescount()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTEMPCOUNT"),
               

        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getindexcount(string userId)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_pickuplocation", new SqlParameter[]
        {



                new SqlParameter("@Command","CHECKUSERIDINDEX"),
                new SqlParameter("@userid1",userId),



        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

        public DataTable getEmployesbyID(int empid)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTBYID"),
                new SqlParameter("@empid",empid),


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getEmployesbyUserID(EmployeeModel objemployeeModel)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTBYUSERID"),
                new SqlParameter("@userId",objemployeeModel.userId),


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getPickupLocationbyuserId(string userId)
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_pickuplocation", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTBYUSERID"),
                new SqlParameter("@userid1",userId),


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }
        public DataTable getworkstatus()
        {
            try
            {
                return Execution.ExecuteParamerizedSelectCommand("sp_employee", new SqlParameter[]
        {



                new SqlParameter("@Command","SELECTWORKSTATUS"),
              


        });
            }
            catch (Exception ex)
            {
                throw ex;
            }





        }

    

    }
}
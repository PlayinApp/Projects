using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapitest.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Webapitest.Controllers
{
    public class LoginController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        SampleEntities db = new SampleEntities();

        [HttpPost]
        //   [Route("GetDetails")]
        public HttpResponseMessage Post()
        {
            var msf = db.Tbl_Driver.AsEnumerable();

            var resp = Request.CreateResponse<LoginResponseModel>(
                HttpStatusCode.OK,
                new LoginResponseModel() { message = "Success", output = msf }
            );
            return resp;
        }

        //[HttpPost]
        //[Route("Getdrivers")]
        //public HttpResponseMessage Getdrivers()
        //{
        //    con.Close();
        //    SqlCommand cmd = new SqlCommand("select * from Tbl_Driver", con);
        //    con.Close();

        //    SqlDataAdapter data = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    data.Fill(dt);



        //  // var msf = db.Tbl_Driver.AsEnumerable();

        //    var resp = Request.CreateResponse<LoginResponseModel>(
        //        HttpStatusCode.OK,
        //        new LoginResponseModel() { message = "Success", output1 = dt }
        //    );
        //    return resp;
        //}
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage login([FromBody] LoginModel loginm)
        {


            con.Close();
            // SqlCommand cmd = new SqlCommand("select * from Tbl_Driver", con);
            loginm.token = "ab0d80c5-df50-4068-8e28-79adf41f74f7";
            var token = loginm.token;
            var mobile = loginm.mobile;
            var pin = loginm.pin;
            SqlCommand cmd = new SqlCommand("select token from login where token='" + token + "'", con);

            con.Close();

            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            data.Fill(dt);
            AuthorizationToken onj = new AuthorizationToken();
         var result=   onj.checkToken(token);
            if (result == true)
            {





            }

            else {



            }
           

            if (dt.Rows.Count > 0)
            {



                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from login where mobile='" + mobile + "' and pin='" + pin + "'", con);
                SqlDataAdapter data1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                con.Close();
                data1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    string usertype = dt1.Rows[0]["userType"].ToString();
                    //  string token;
                    if (usertype == "supervisor")
                    {
                        int sp1 = Convert.ToInt16(dt1.Rows[0]["supervisorId"].ToString());
                        con.Open();
                        SqlCommand cmd3 = new SqlCommand("select * from supervisor where superVisorId='" + sp1 + "'", con);
                        SqlDataAdapter data3 = new SqlDataAdapter(cmd3);
                        DataTable dt3 = new DataTable();
                        con.Close();
                        data3.Fill(dt3);

                        var resp = Request.CreateResponse<LoginResponseModel>(
                                        HttpStatusCode.OK,
                                        new LoginResponseModel() { message = "login sucessfull", token = token, output1 = dt3, statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                    );
                        return resp;



                    }





                    var resp3 = Request.CreateResponse<LoginResponseModel>(
                                                   HttpStatusCode.OK,
                                                   new LoginResponseModel() { message = "login sucessfull", output1 = dt1 }
                                               );
                    return resp3;
                }

                else
                {

                    var resp3 = Request.CreateResponse<LoginResponseModel>(
                                                                       HttpStatusCode.OK,
                                                                       new LoginResponseModel() { message = "Mobile or Pin Wrong", statuscode = Convert.ToInt16(HttpStatusCode.OK) }
                                                                   );
                    return resp3;


                }




            }

            else

            {



                var resp1 = Request.CreateResponse<LoginResponseModel>(
                                HttpStatusCode.OK,
                                new LoginResponseModel() { message = "unauthorized" }
                            );
                return resp1;
            }



            // var msf = db.Tbl_Driver.AsEnumerable();



        }


        [HttpPost]
        [Route("supervisor/register_Driver")]
        public HttpResponseMessage RegisterDriver([FromBody] DriverModel driverm)
        {

            string name = driverm.name;
            string email = driverm.email;
            int age = driverm.age;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@name", driverm.name);
            //cmd.Parameters.AddWithValue("@email", driverm.email);
            //cmd.Parameters.AddWithValue("@age", driverm.age);
            //cmd.Parameters.AddWithValue("@emergencyContact", driverm.emergencyContact);
            //cmd.Parameters.AddWithValue("@panno", driverm.panno);
            //cmd.Parameters.AddWithValue("@aadharno", driverm.aadharNo);
            //cmd.Parameters.AddWithValue("@experience", driverm.experience);
            //cmd.Parameters.AddWithValue("@currentAddr", driverm.currentAddr);
            //cmd.Parameters.AddWithValue("@permanentAaddr", driverm.permanentAaddr);
            //cmd.Parameters.AddWithValue("@licenceno", driverm.licenceno);
            //cmd.Parameters.AddWithValue("@fromdateTodate", driverm.fromdateTodate);

            //cmd.Parameters.AddWithValue("@transportCompany", driverm.transportCompany);


            //cmd.Parameters.AddWithValue("@vehicleno", driverm.vehicleno);
            //cmd.Parameters.AddWithValue("@profilePic", driverm.profilePic);
            //cmd.Parameters.AddWithValue("@bloodGroup", driverm.bloodGroup);
          
            //cmd.Parameters.AddWithValue("@eyeSight", driverm.eyeSight);
            //cmd.Parameters.AddWithValue("@breathTest", driverm.breathTest);

            //cmd.Parameters.AddWithValue("@lifeInsurance", driverm.lifeInsurance);



            //cmd.Parameters.AddWithValue("@isSmoke", driverm.isSmoke);
            //cmd.Parameters.AddWithValue("@physicalInjuries", driverm.physicalInjuries);
            //cmd.Parameters.AddWithValue("@otherhealthIssues", driverm.otherhealthIssues);
            //cmd.Parameters.AddWithValue("@driverDeviceid", driverm.deviceId);

            //cmd.Parameters.AddWithValue("@status",1);
          


            con.Open();
            SqlCommand cmd4 = new SqlCommand("insert into driver(name,email,age)values('" + name + "','" + email + "','" + age + "')", con);
            cmd4.ExecuteNonQuery();
            con.Close();

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "driver Register sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) } );
            return resp;
        }
        [HttpPost]
        [Route("supervisor/Driver_List")]
        public HttpResponseMessage driverList()
        {

           
            //cmd.CommandType = CommandType.StoredProcedure;
            
            //cmd.Parameters.AddWithValue("@command","DRIVERLIST" );

            //cmd.Parameters.AddWithValue("@status",1);



            

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

        [HttpPost]
        [Route("supervisor/RegisterVehicle")]
        public HttpResponseMessage Registervehicle([FromBody] VehicleModel vehicleM)
        {

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@vehNameModel", vehicleM.vehNameModel);
            //cmd.Parameters.AddWithValue("@vehicleRegNo", vehicleM.vehicleRegNo);
            //cmd.Parameters.AddWithValue("@vehicleCondition", vehicleM.vehicleCondition);
            //cmd.Parameters.AddWithValue("@isContainFirstAID", vehicleM.isContainFirstAID);
            //cmd.Parameters.AddWithValue("@isContainAirbags", vehicleM.isContainAirbags);
            //cmd.Parameters.AddWithValue("@isContainsFireControll", vehicleM.isContainsFireControll);
            //cmd.Parameters.AddWithValue("@isVehicleowned",vehicleM.isVehicleowned);
            //cmd.Parameters.AddWithValue("@ownername", vehicleM.ownername);
            //cmd.Parameters.AddWithValue("@ownerNumder", vehicleM.ownerNumder);
            //cmd.Parameters.AddWithValue("@ownerAddress", vehicleM.ownerAddress);
            //cmd.Parameters.AddWithValue("@inspectedBy", vehicleM.inspectedBy);
          
            //cmd.Parameters.AddWithValue("@vehicleType", vehicleM.vehicletype);



            string name = vehicleM.vehicleRegNo;
            string email = vehicleM.vehNameModel;
            int age = vehicleM.vehicleId;



            con.Open();
            SqlCommand cmd4 = new SqlCommand("insert into driver(name,email,age)values('" + name + "','" + email + "','" + age + "')", con);
            cmd4.ExecuteNonQuery();
            con.Close();

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "driver Register sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }
        [HttpPost]
        [Route("supervisor/Vehicle_List")]
        public HttpResponseMessage vehicleList()
        {


            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@command","VEHICLELIST" );

            //cmd.Parameters.AddWithValue("@status",1);





            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

        [HttpPost]
        [Route("supervisor/create_routes")]
        public HttpResponseMessage createRoutes([FromBody] Routenames objroutename)
        {

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@routeName", objroutename.routeName);
            //cmd.Parameters.AddWithValue("@empId", objroutename.empId);
            //cmd.Parameters.AddWithValue("@shift", objroutename.shift);
            //cmd.Parameters.AddWithValue("@status", objroutename.status);
           
           


            


          

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "routes Register sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }


        [HttpPost]
        [Route("supervisor/Routes_List")]
        public HttpResponseMessage routesList()
        {


            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@command","ROUTESLIST" );

            //cmd.Parameters.AddWithValue("@status",1);





            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }


        [HttpPost]
        [Route("supervisor/schedule_routes")]
        public HttpResponseMessage scheduleRoutes([FromBody] Scheduleroutes objScheduleroutes)
        {

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@routeid", objScheduleroutes.routeid);
            //cmd.Parameters.AddWithValue("@driverid", objScheduleroutes.driverid);
            //cmd.Parameters.AddWithValue("@vehicleId", objScheduleroutes.vehicleId);
            //cmd.Parameters.AddWithValue("@triptype", objScheduleroutes.triptype);









            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "scheduled Routes sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

        [HttpPost]
        [Route("supervisor/scheduleRoutes_List")]
        public HttpResponseMessage scheduleRoutesList()
        {


            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@command","SCHEDULEROUTELIST" );

            //cmd.Parameters.AddWithValue("@status",1);





            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }



        [HttpPost]
        [Route("supervisor/create_Shifts")]
        public HttpResponseMessage createShifts([FromBody] ShiftModel objShifts)
        {

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@shiftId", objShifts.shiftId);
            //cmd.Parameters.AddWithValue("@shiftName", objShifts.shiftName);
            //cmd.Parameters.AddWithValue("@status", objShifts.status);
           








            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "shift created sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

        [HttpPost]
        [Route("supervisor/shift_List")]
        public HttpResponseMessage shiftList([FromBody] ShiftModel objShift)
        {

            //cmd.CommandType = CommandType.StoredProcedure;


            //cmd.Parameters.AddWithValue("@Command","SHIFTLIST");
            //cmd.Parameters.AddWithValue("@status",1);














            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }





        [HttpPost]
        [Route("supervisor/create_Employee")]
        public HttpResponseMessage createEmplyee([FromBody] EmployeeModel objEmployee)
        {

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@empId", objEmployee.empId);
            //cmd.Parameters.AddWithValue("@name", objEmployee.name);
            //cmd.Parameters.AddWithValue("@presentAddress", objEmployee.presentAddress);
            //cmd.Parameters.AddWithValue("@landmark", objEmployee.landmark);
            //cmd.Parameters.AddWithValue("@gender", objEmployee.gender);
            //cmd.Parameters.AddWithValue("@companyBranch", objEmployee.companybranch);
            //cmd.Parameters.AddWithValue("@pickuplocation", objEmployee.pickuplocation);
            //cmd.Parameters.AddWithValue("@pickupLatitude", objEmployee.pickupLatitude);
            //cmd.Parameters.AddWithValue("@pickupLongitude", objEmployee.pickupLongitude);
            //cmd.Parameters.AddWithValue("@profilePic", objEmployee.profilePic);
            //cmd.Parameters.AddWithValue("@deviceId", objEmployee.deviceId);
            //cmd.Parameters.AddWithValue("@locationId", objEmployee.locationId);
            //cmd.Parameters.AddWithValue("@Age", objEmployee.Age);
            //cmd.Parameters.AddWithValue("@shift", objEmployee.shift);
            //cmd.Parameters.AddWithValue("@status",1);

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "Employee created sucessfully", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }

        [HttpPost]
        [Route("supervisor/employee_List")]
        public HttpResponseMessage employeeList([FromBody] EmployeeModel objEmployee)
        {

            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@shift", objEmployee.shift);
            //cmd.Parameters.AddWithValue("@Command","EMPLOYEELISTBYSHIFT");
            //cmd.Parameters.AddWithValue("@status",1);

            var resp = Request.CreateResponse<LoginResponseModel>(HttpStatusCode.OK,
 new LoginResponseModel() { message = "ok succesful", statuscode = Convert.ToInt16(HttpStatusCode.OK) });
            return resp;
        }




    }
}

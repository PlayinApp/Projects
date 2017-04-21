using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webmvc.Models;
using System.Data.Entity;

namespace Webmvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {


            var studentList = new List<student>{
                            new student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                            new student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
                        };
           

            return View(studentList);
        }

        public void notify() {



            FCMPushNotification fn = new FCMPushNotification();
            fn.SendNotification("notification","from krishna","topic");


        }

        public void test()
        {


            shiftdbcontext db = new shiftdbcontext();
            string commandText = "EXEC [dbo].[sp_shifts] @shiftId,@shiftname, @command";




            var employees = db.Database.SqlQuery<Shift>(commandText, new SqlParameter("@shiftId", 1),
                            new SqlParameter("@shiftname", "krishna"),
                            new SqlParameter("@command", "SELECTALL")).ToList();










            string shiftname2 = "testshift";
        //    string Command = "INSERT";
        //SqlParameter latParam = new SqlParameter("@shiftname", shiftname);
        //    SqlParameter lngParam = new SqlParameter("@command", Command);

            var param1 = new SqlParameter
            {
                ParameterName = "@shiftname",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "tsset"
            };

            //Second input parameter
            var param2 = new SqlParameter
            {
                ParameterName = "@command",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = "INSERT"
            };


            var shiftname = new SqlParameter
            {
                DbType = DbType.String,
                ParameterName = "@shiftname",
                Value = "test"
            };
            var command = new SqlParameter
            {
                DbType = DbType.String,
                ParameterName = "@command",
                Value = "SELECTALL"
            };
          //  object[] parameters = new object[] { latParam, lngParam };


         //var list=   db.Database.ExecuteSqlCommand("EXEC [dbo].[sp_shifts]",shiftname, command);
          
         db.Database.ExecuteSqlCommand(
                            "EXEC [dbo].[sp_shifts] @shiftId,@shiftname, @command",
                              new SqlParameter("@shiftId", 1),
                            new SqlParameter("@shiftname", "krishna"),
                            new SqlParameter("@command", "select")
                            
                        );


            
            db.SaveChanges();
        }

    }
}
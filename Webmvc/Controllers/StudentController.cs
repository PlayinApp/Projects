using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webmvc.Models;

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
     
    }
}
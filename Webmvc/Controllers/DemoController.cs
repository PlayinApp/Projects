using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {

         
            return View();
        }
        public IEnumerable<sp_driver_Result> testex() {

            vahiniEntities2 db = new vahiniEntities2();
            var list = db.sp_driver(1, "GETTRIPEMPLIST");
            return list;




        }

    }
}
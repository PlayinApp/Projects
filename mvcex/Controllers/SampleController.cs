using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcex.Models;
using System.Web.Routing;


namespace mvcex.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
          //  vahiniEntities db = new vahiniEntities();
       //  var list=  db.sp_driver(null,1, "GETTRIPEMPLIST");
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteSharingSystem.Areas.Students_A.Controllers
{
    public class HomeController : Controller
    {
        // GET: Students_A/Home
        public ActionResult StudentIndex()
        {
            return View();
        }
    }
}
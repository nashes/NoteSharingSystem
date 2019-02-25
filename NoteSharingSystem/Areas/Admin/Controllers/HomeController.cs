using NoteSharingSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteSharingSystem.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        NoteSharingDb  db= new NoteSharingDb();
        public ActionResult AdminIndex()
        {
            


            return View();
        }
    }
}
using NoteSharingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteSharingSystem.DAL;

namespace NoteSharingSystem.Controllers
{
    public class HomeController : Controller
    {
        NoteSharingDb db = new NoteSharingDb();
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Identity _identity)
        {
            Identity identity = db.Identities.SingleOrDefault(x=>x.Name==_identity.Name && x.Password==_identity.Password);

            if (identity != null) { 
                Session["User"] = identity;
            if (identity.Authority == 2)
            {
                Session["Tables"]= db.Database.SqlQuery<string>("Select name From  sys.tables Order By name").ToList();
                return RedirectToAction("AdminIndex", "Home", new { area = "Admin" });
            }
            else if (identity.Authority == 1)
            {
                return RedirectToAction("StudentIndex", "Home", new { area = "Students_A" });
            }
            else
            {
                return RedirectToAction("StudentIndex", "Home", new { area = "Lecturers_A" });

            }

            }
            else return RedirectToAction("Index", "Home");


           
        }


    }
}
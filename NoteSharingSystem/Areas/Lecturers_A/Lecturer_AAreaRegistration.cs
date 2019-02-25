using System.Web.Mvc;

namespace NoteSharingSystem.Areas.Lecturer_A
{
    public class Lecturer_AAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Lecturer_A";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Lecturer_A_default",
                "Lecturer_A/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
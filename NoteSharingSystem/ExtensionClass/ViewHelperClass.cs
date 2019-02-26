using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteSharingSystem.ExtensionClass
{
    public class ViewHelperClass
    {
        public static string ToSelectList<T>(T table,string TextField,string ValeField) where T :class
        {
            
            List<SelectListItem> list = new List<SelectListItem>();
            
            



            return  string.Empty;
        }
    }
}
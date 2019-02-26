using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models.ViewModels
{
    public class DepartmantCreateView
    {
        public Deparmant deparmant { get; set; }
        public string presedent  { get; set; }
        public string university { get; set; }
        public IEnumerable<dynamic>  Identities{ get; set; }
        public IEnumerable<dynamic>  universities { get; set; }
        public DepartmantCreateView(Deparmant deparmant, IEnumerable<dynamic> Identities, IEnumerable<dynamic> universities)
        {
            this.universities = universities;
            this.Identities = Identities;
            this.deparmant = deparmant;
        }
        public DepartmantCreateView()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models.ViewModels
{
    public class LectureViewCreate
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int term { get; set; }
        public int MyProperty { get; set; }
        public virtual string instructer { get; set; }
        public virtual IEnumerable<dynamic> insturcters { get; set; }
        public virtual string departmant { get; set; }
        public virtual IEnumerable<dynamic> departmants { get; set; }
        public LectureViewCreate(IEnumerable<dynamic> insturcters, IEnumerable<dynamic> departmants)
        {
            this.insturcters = insturcters;
            this.departmants = departmants;

        }
        public LectureViewCreate()
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Lecture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int term  { get; set; }
        public int MyProperty { get; set; }
        public virtual Instructer Instructer { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual Deparmant Deparmant { get; set; }




    }
}
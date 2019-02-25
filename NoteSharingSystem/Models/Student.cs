using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Identity Identity { get; set; }
        public Deparmant Deparmant { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Note> Notes{ get; set; }
        public Decimal GNO { get; set; }
        public int Registeration { get; set; }

    }
}
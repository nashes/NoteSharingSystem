using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Deparmant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual University university { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual Identity presedent { get; set; }
 


    }
}
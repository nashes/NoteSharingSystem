using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Instructer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Identity Identity { get; set; }
        public Deparmant deparmant { get; set; }
        public University university { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
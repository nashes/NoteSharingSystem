using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Note
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }
        public  Lecture Lecture { get; set; }
        public  Identity Publisher { get; set; }
        public   Rate rate { get; set; }
        public string Content { get; set; }
     
    }
}
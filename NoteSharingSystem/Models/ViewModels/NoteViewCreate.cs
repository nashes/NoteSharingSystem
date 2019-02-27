using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models.ViewModels
{
    public class NoteViewCreate
    {
        public Lecture Lecture { get; set; }
        public Identity Publisher { get; set; }
        public Rate rate { get; set; }
        public string Content { get; set; }
    }
}
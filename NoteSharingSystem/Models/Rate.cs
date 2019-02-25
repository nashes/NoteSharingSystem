using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Rate
    {
        
        public int Id { get; set; }
        public ICollection<string> comments { get; set; }
        public int numberOfRate { get; set; }
        public int totalPoint { get; set; }


    }
}
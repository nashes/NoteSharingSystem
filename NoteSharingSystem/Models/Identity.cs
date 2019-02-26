using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteSharingSystem.Models
{
    public class Identity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Birth { get; set; }
        public string Province { get; set; }
        public string ImageAd { get; set; }
        public string Nation { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }

        public static implicit operator string(Identity v)
        {
            throw new NotImplementedException();
        }
    }
}
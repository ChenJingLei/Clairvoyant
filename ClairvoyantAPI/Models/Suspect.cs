using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClairvoyantAPI.Models
{
    public class Suspect : Person
    {
        public string Crime { set; get; }

        public string Experience { get; set; }
    }
}
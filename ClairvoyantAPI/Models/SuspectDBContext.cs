using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClairvoyantAPI.Models
{
    public class SuspectDBContext : DbContext
    {
        public DbSet<Suspect> Suspects { get; set; }
    }
}
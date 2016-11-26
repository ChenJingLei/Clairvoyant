using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClairvoyantAPI.Models
{
    public class ChildrenDBContext : DbContext
    {
        public DbSet<Children> Childrens { get; set; }
    }
}
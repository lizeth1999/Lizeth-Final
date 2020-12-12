using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lizeth.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {
            
        }

        public System.Data.Entity.DbSet<Lizeth.Models.Numero> Numeroes { get; set; }
    }
}
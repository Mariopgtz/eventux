using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventux.Domain.Models
{
    using Eventux.Common.Models;
    using System.Data.Entity;
    public class Datacontext : DbContext
    {
        public Datacontext() : base("DefaultConnection")
        {

        }

        public DbSet<Servicios> Servicios { get; set; }
    }
}

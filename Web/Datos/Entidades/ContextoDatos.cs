
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Datos.Entidades
{
    public class ContextoDatos:DbContext
    {
        public ContextoDatos() : base("name=ContextoDatos")
        {

        }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}

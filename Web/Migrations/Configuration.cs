namespace Web.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Datos.Entidades.ContextoDatos>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Web.Datos.Entidades.ContextoDatos context)
        {
            if (!context.Ciudades.Any())
            {
                List<Datos.Entidades.Ciudad> ciudad = new List<Datos.Entidades.Ciudad>
                {
                new Datos.Entidades.Ciudad { Nombre = "Bogotá", Codigo="1"},
                new Datos.Entidades.Ciudad { Nombre = "Cali", Codigo="2"},};
                ciudad.ForEach(s => context.Ciudades.AddOrUpdate(p => p.Nombre, s));
                context.SaveChanges();
            };

            if (!context.Vendedores.Any())
            {
                List<Datos.Entidades.Vendedor> vendedor = new List<Datos.Entidades.Vendedor>
                {
                new Datos.Entidades.Vendedor { Codigo="10", Nombre="JUAN", Apellido="POLANCO", CiudadId=1, Numero_Identificacion="1111111111"},
                 new Datos.Entidades.Vendedor { Codigo="20", Nombre="PEDRO", Apellido="REYES", CiudadId=2, Numero_Identificacion="2222222222"},
                 new Datos.Entidades.Vendedor { Codigo="30", Nombre="MARIA",Apellido="PAZ", CiudadId=1, Numero_Identificacion="3333333333"},
                 new Datos.Entidades.Vendedor { Codigo="20", Nombre="LUNA", Apellido="MONROY", CiudadId=2, Numero_Identificacion="4444444444"},
                };
                vendedor.ForEach(s => context.Vendedores.AddOrUpdate(p => p.Nombre, s));
                context.SaveChanges();
            };
        }
    }
}

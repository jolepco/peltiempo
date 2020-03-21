using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class ModeloCompleto
    {
        public ModeloCompleto()
        {
            listaCiudades = new SelectList(new List<SelectList>());
        }

        public Datos.Entidades.Ciudad ciudad { get; set; }
        public List<Datos.Entidades.Vendedor> vendedores { get; set; }

        public SelectList listaCiudades { get; set; }

    }
}
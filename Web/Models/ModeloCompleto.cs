using System.Collections.Generic;
using System.Web.Mvc;

namespace Web.Models
{
    public class ModeloCompleto
    {
        public string Title { get; set; }
        public ModeloCompleto()
        {
            listaCiudades = new SelectList(new List<SelectList>());
        }

        public Datos.Modelos.CiudadModel ciudad { get; set; }
        public List<Datos.Modelos.VendedoresModel> vendedores { get; set; }

        public List<Datos.Modelos.ComboModel> Combosciudad { get; set; }

        public SelectList listaCiudades { get; set; }

    }
}
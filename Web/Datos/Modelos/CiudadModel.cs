using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Datos.Modelos
{
    public class CiudadModel
    {
        public int CiudadId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class VendedoresModel
    {
        public VendedoresModel()
        {
            listaCiudades = new SelectList(new List<SelectList>());
            combociudades = new List<ComboModel>();
            ciudadantiguaid = 0;
        }
        public int VendedorId { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Numero_Identificacion { get; set; }

        public int CiudadId { get; set; }
        public virtual CiudadModel Ciudad { get; set; }

        public SelectList listaCiudades { get; set; }

        public int ciudadantiguaid { get; set; }
        public List<Datos.Modelos.ComboModel> combociudades { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Datos.Modelos
{
    public class ParametroConsulta
    {
        public int codigo { get; set; }
    }

    public class ParametroConsultaGuardar
    {
        public Models.ModeloCompleto modelo { get; set; }
    }

    public class ParametroConsultaCiudad
    {
        public Datos.Modelos.CiudadModel  modelo { get; set; }
    }
    
    public class ParametroConsultaVendedores
    {
        public Datos.Modelos.VendedoresModel  modelo { get; set; }
    }
}
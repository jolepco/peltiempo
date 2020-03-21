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
}
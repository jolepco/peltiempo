using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Datos.Modelos
{
    public class ResponseModel
    {
        public dynamic result { get; set; }
        public bool response { get; set; }
        public string message { get; set; }
        public string href { get; set; }
        public string function { get; set; }

        public string title { get; set; }

        public ResponseModel()
        {
            this.response = false;
            this.message = "Ocurrio un error inesperado";
        }

        public void SetResponse(bool response, string message = "", string title = "")
        {
            this.response = response;
            this.message = message;
            this.title = title;

            if (!response && message == "") this.message = "Ocurrio un error inesperado";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/Common")]
    public class ApiCiudadVendedoresController : ApiController
    {
        #region ciudad
        [HttpGet]
        [Route("obtenerciudades")]
        public HttpResponseMessage Obtenerciudad()
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().ObtenerTodaslasCiudades().Result;


                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return response;
        }


        [HttpPut]
        [Route("EliminarCiudad")]
        public HttpResponseMessage Eliminarciudad([FromBody]Datos.Modelos.ParametroConsulta paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().EliminarCiudad(paramQuery.codigo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {

            }

            return response;
        }


        #endregion

        #region vendedor
        [HttpPut]
        [Route("obtenervendedor")]
        public HttpResponseMessage Obtener2([FromBody]Datos.Modelos.ParametroConsulta paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().ObtenerunVendedor(paramQuery.codigo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return response;
        }


        [HttpPut]
        [Route("obtenerVendedoresCiudad")]
        public HttpResponseMessage ObtenervenCiudad([FromBody]Datos.Modelos.ParametroConsulta paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().ObtenerunVendedorCiudad(paramQuery.codigo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return response;
        }



        [HttpPut]
        [Route("guardarvendedor")]
        public HttpResponseMessage Obtenevendedor2([FromBody]Datos.Modelos.VendedoresModel paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().GuardarVendedor(paramQuery);

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return response;
        }

        [HttpPut]
        [Route("EliminarVendedor")]
        public HttpResponseMessage Eliminarven([FromBody]Datos.Modelos.ParametroConsulta paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().EliminarVendedor(paramQuery.codigo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {

            }

            return response;
        }


        #endregion

        #region obtener modelo
        [HttpPut]
        [Route("obtenermodelo")]
        public HttpResponseMessage obtenerunmodelo([FromBody]Datos.Modelos.ParametroConsulta paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().ObtenerunCiudadVendedor(paramQuery.codigo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        #endregion

        #region guardado
        [HttpPut]
        [Route("guardarCiudadVendedor")]
        public HttpResponseMessage guardadogeneral([FromBody]Datos.Modelos.ParametroConsultaGuardar paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().GuardarCiudadVendedor(paramQuery.modelo).Result;

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        [HttpPut]
        [Route("guardarciudad")]
        public HttpResponseMessage guardadociudadees([FromBody]Datos.Modelos.ParametroConsultaCiudad paramQuery)
        {
            HttpResponseMessage response = Request.CreateResponse();

            try
            {

                var listaSqlFiltrada = new Negocio.NegCiudadVendedor().GuardarCiudad(paramQuery.modelo);

                string listaJson = Newtonsoft.Json.JsonConvert.SerializeObject(listaSqlFiltrada);

                var jsonContent = new StringContent(listaJson, Encoding.UTF8, "application/json");

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = jsonContent;
                response.ReasonPhrase = "OK";
            }
            catch (Exception ex)
            {

            }

            return response;
        }

        #endregion
    }
}

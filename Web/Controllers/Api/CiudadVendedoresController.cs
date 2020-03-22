using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Web.Datos.Modelos;

namespace Web.Controllers.Api
{
    public class CiudadVendedoresController : Controller
    {
        private string url = ConfigurationManager.AppSettings["url"].ToString();

        // GET: CiudadVendedores
        #region Contructores
        public CiudadVendedoresController()
        {

        }
        #endregion

        #region Metodo Publicos

        public ActionResult Index()
        {
            return View("~/Views/CiudadVendedores/Index.cshtml", new List<Datos.Modelos.CiudadModel>());
            // return View();
        }

        public ActionResult _Lista()
        {
            List<Datos.Modelos.CiudadModel> model = new List<Datos.Modelos.CiudadModel>();

            model = obtenerciudades();
            return PartialView("~/Views/CiudadVendedores/listarCiudades.cshtml", model);
        }



        public ActionResult _ListarVendedores(int id)
        {
            List<Datos.Modelos.VendedoresModel> model = new List<Datos.Modelos.VendedoresModel>();

            model = obtenerCiudadVendedor(id).vendedores;

            return PartialView("~/Views/CiudadVendedores/detalleVendedor.cshtml", model);
        }

        public ActionResult _Agregar(int? id)
        {
            Models.ModeloCompleto modelo = new Models.ModeloCompleto();

            if (id != null)
            {
                modelo = obtenerCiudadVendedor((int)id);
                modelo.listaCiudades = new SelectList(modelo.Combosciudad, "Id", "Nombre");
            }
            else
            {
                modelo.ciudad = new CiudadModel();
                modelo.Combosciudad = new List<ComboModel>();
                modelo.vendedores = new List<VendedoresModel>();
            }
            return PartialView("~/Views/CiudadVendedores/_Agregar.cshtml", modelo);
        }
        public ActionResult _AgregarVendedor(int? id, int ciudad)
        {
            Datos.Modelos.VendedoresModel modelo = new VendedoresModel();

            if (id != null)
            {
                modelo = obtenerunVendedor((int)id);
                modelo.listaCiudades = new SelectList(modelo.combociudades, "Id", "Nombre", modelo.Ciudad.CiudadId);
                modelo.ciudadantiguaid = ciudad;
            }
            else
            {
                modelo.CiudadId = ciudad;
                modelo.ciudadantiguaid = ciudad;
            }

            return PartialView("~/Views/CiudadVendedores/AgregarVendedor.cshtml", modelo);
        }


        public ActionResult agregarnuevaciudad()
        {
            Datos.Modelos.CiudadModel modelo = new CiudadModel();

            return PartialView("~/Views/CiudadVendedores/AgregarCiudad.cshtml", modelo);

        }

        [HttpPost]
        public ActionResult agregarciudad(Datos.Modelos.CiudadModel ciudad)
        {
            bool repuesta = agregarciudadNueva(ciudad);

            var modelo = obtenerciudades();

            return PartialView("~/Views/CiudadVendedores/listarCiudades.cshtml", modelo);

        }


        [HttpPost]
        public ActionResult AgregarVendedor(Datos.Modelos.VendedoresModel vendedor)
        {
            if (vendedor.CiudadId ==0)
            {
                vendedor.CiudadId = vendedor.ciudadantiguaid;
            }
            bool repuesta = agregarVendedorNuevo(vendedor);

            var modelo = obtenerVendedores(vendedor.ciudadantiguaid);

            return PartialView("~/Views/CiudadVendedores/detalleVendedor.cshtml", modelo);

        }


        public ActionResult _EliminarVendedor(int id, int ciudad)
        {
            var res = new ResponseModel();
        

                res.result = EliminarVendedor(id);

                if (res.result)
                {
                    var modelo = obtenerVendedores(ciudad);

                    return PartialView("~/Views/CiudadVendedores/detalleVendedor.cshtml", modelo);

                }

            return Json(res);
        }



        public JsonResult _EliminarCiudad(int id)
        {
            var res = new ResponseModel();
            if (ModelState.IsValid)
            {
                var update = true;


                res.result = Eliminarciudad(id);

                if (res.result)
                {
                    var mensaje = update ? string.Format("{0}", "LA CIUDAD SE ELIMINO") : "";
                    var _fuction = $"g_notificacionesNotify('success','bottom right','Ok!" +
                        $"','{ mensaje}  {string.Format("{0}", "Ciudad ")} { "ok" } !');Listar()";
                    res.message = "";
                    res.function = _fuction;

                    return Json(res, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(res);
        }
        #endregion

        #region procesos de ajax
        public List<Datos.Modelos.CiudadModel> obtenerciudades()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    var responseTask = client.GetAsync("api/Common/obtenerciudades");

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var _ciudades = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Datos.Modelos.CiudadModel>>(res);
                        return _ciudades;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public Models.ModeloCompleto obtenerCiudadVendedor(int ciudad)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsulta model = new ParametroConsulta
                    {
                        codigo = ciudad,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/obtenermodelo", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var _ciudades = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ModeloCompleto>(res);
                        return _ciudades;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public Datos.Modelos.VendedoresModel obtenerunVendedor(int vendedor)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsulta model = new ParametroConsulta
                    {
                        codigo = vendedor,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/obtenervendedor", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var _vendedor = Newtonsoft.Json.JsonConvert.DeserializeObject<Datos.Modelos.VendedoresModel>(res);
                        return _vendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public bool agregarciudadNueva(Datos.Modelos.CiudadModel ciudad)
        {
            bool respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsultaCiudad model = new ParametroConsultaCiudad
                    {
                        modelo = ciudad,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/guardarciudad", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        // var _vendedor = Newtonsoft.Json.JsonConvert.DeserializeObject<Datos.Modelos.VendedoresModel>(res);
                        return true; ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }
        public bool agregarVendedorNuevo(Datos.Modelos.VendedoresModel vendedor)
        {
            bool respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsultaVendedores model = new ParametroConsultaVendedores
                    {
                        modelo = vendedor,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/guardarvendedor", model.modelo);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        // var _vendedor = Newtonsoft.Json.JsonConvert.DeserializeObject<Datos.Modelos.VendedoresModel>(res);
                        return true; ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }
        public bool Eliminarciudad(int id)
        {
            bool respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsulta model = new ParametroConsulta
                    {
                        codigo = id,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/EliminarCiudad", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return true; ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }
        public List<Datos.Modelos.VendedoresModel> obtenerVendedores(int ciudad)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsulta model = new ParametroConsulta
                    {
                        codigo = ciudad,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/obtenermodelo", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var _vendedores = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ModeloCompleto>(res).vendedores;
                        return _vendedores;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public bool EliminarVendedor(int id)
        {
            bool respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    Datos.Modelos.ParametroConsulta model = new ParametroConsulta
                    {
                        codigo = id,
                    };

                    var responseTask = client.PutAsJsonAsync("api/Common/EliminarVendedor", model);

                    responseTask.Wait();

                    var result = responseTask.Result;

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var res = readTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return true; ;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return respuesta;
        }

        #endregion

    }
}
